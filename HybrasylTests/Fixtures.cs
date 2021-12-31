﻿using Hybrasyl;
using Hybrasyl.Objects;
using Hybrasyl.Xml;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Xunit;
using Map = Hybrasyl.Map;
using Reactor = Hybrasyl.Xml.Reactor;
using Warp = Hybrasyl.Xml.Warp;
using Serilog;
using Xunit.Abstractions;
using Xunit.Sdk;
using Direction = Hybrasyl.Xml.Direction;
using Game = Hybrasyl.Game;

namespace HybrasylTests
{

    public class HybrasylFixture : IDisposable
    {
        public Map Map { get; }
        public Item TestItem { get; }
        public Item StackableTestItem { get; }
        public Dictionary<EquipmentSlot, Item> TestEquipment { get;  }= new();
        public static byte InventorySize => 59;
        private IMessageSink sink;

        public User TestUser { get; }

        public HybrasylFixture(IMessageSink sink)
        {
            this.sink = sink;
            sink.OnMessage(new DiagnosticMessage("hello"));
            Log.Logger = new LoggerConfiguration()
                .WriteTo.TestOutput(sink)
                .CreateLogger(); var submoduleDir = AppDomain.CurrentDomain.BaseDirectory.Split("HybrasylTests");
            Game.LoadCollisions();

            Game.World = new World(1337, new DataStore {Host = "127.0.0.1", Port = 6379, Database = 15},
                Path.Combine(submoduleDir[0], "HybrasylTests"), true);

            if (!Game.World.LoadData())
                throw new InvalidDataException("LoadData encountered errors");

            var xmlMap = new Hybrasyl.Xml.Map
            {
                Id = 136,
                X = 12,
                Y = 12,
                Name = "Test Inn",
                Warps = new List<Warp>(),
                Npcs = new List<MapNpc>(),
                Reactors = new List<Reactor>(),
                Signs = new List<MapSign>()
            };
            var map = new Map(xmlMap, Game.World);
            Game.World.WorldData.SetWithIndex(map.Id, map, map.Name);

            var xmlNation = new Nation { Default = true, Description = "Test Nation", Flag = 0, Name = "Test", SpawnPoints = new List<SpawnPoint> {new() { MapName = "Test Map", X = 5, Y = 5 }}};
            Game.World.WorldData.Set(xmlNation.Name, xmlNation);

            TestItem = new Item
            {
                Name = "Test Item"
            };
            TestItem.Properties.Stackable.Max = 1;
            TestItem.Properties.Equipment = new Hybrasyl.Xml.Equipment { WeaponType = WeaponType.None, Slot = EquipmentSlot.None };
            TestItem.Properties.Physical = new Physical { Durability = 1000, Weight = 1 };
            TestItem.Properties.Categories = new List<Category>
            {
                new() {Value = "junk"},
                new() {Value = "xmlitem"}
            };
            Game.World.WorldData.Set(TestItem.Id, TestItem);

            StackableTestItem = new Item
            {
                Name = "Stackable Test Item"
            };
            StackableTestItem.Properties.Stackable.Max = 20;
            StackableTestItem.Properties.Equipment = new Hybrasyl.Xml.Equipment() { WeaponType = WeaponType.None, Slot = EquipmentSlot.None };
            StackableTestItem.Properties.Physical = new Physical { Durability = 1000, Weight = 1 };
            StackableTestItem.Properties.Categories = new List<Category>
            {
                new() { Value = "nonjunk" },
                new() { Value = "stackable" },
                new() { Value = "xmlitem" }
            };

            Game.World.WorldData.Set(StackableTestItem.Id, StackableTestItem);

            foreach (EquipmentSlot slot in Enum.GetValues(typeof(EquipmentSlot)))
            {
                var item = new Item() { Name = $"Equip Test {slot}" };
                item.Properties.Stackable.Max = 1;
                item.Properties.Equipment = new Hybrasyl.Xml.Equipment { WeaponType = slot == EquipmentSlot.Weapon ? WeaponType.Dagger : WeaponType.None, Slot = slot };
                item.Properties.Physical = new Physical { Durability = 1000, Weight = 1 };
                Game.World.WorldData.Set(item.Id, item);
                TestEquipment.Add(slot, item);
            }

            TestUser = new User
            {
                Name = "TestUser",
                Uuid = Guid.NewGuid().ToString(),
                Gender = Gender.Female,
                Location =
                {
                    Direction = Direction.South,
                    Map = map,
                    X = 4,
                    Y = 10
                },
                HairColor = 1,
                HairStyle = 1,
                Class = Class.Peasant,
                Gold = 0,
                AuthInfo =
                {
                    CreatedTime = DateTime.Now,
                    FirstLogin = true,
                    PasswordHash = "testing",
                    LastPasswordChange = DateTime.Now,
                    LastPasswordChangeFrom = "TestFixture"
                },
                Stats =
                {
                    BaseInt = 100, 
                    BaseStr = 255, 
                    BaseDex = 100, 
                    BaseCon = 100, 
                    BaseWis = 100,
                    Level = 99
                }
            };
            TestUser.AuthInfo.Save();
            TestUser.Nation = Game.World.DefaultNation;

            var vault = new Vault(TestUser.Uuid);
            vault.Save();
            var parcelStore = new ParcelStore(TestUser.Uuid);
            parcelStore.Save();
            TestUser.Save();


        }

        public void ResetUserStats()
        {
            TestUser.Stats.BaseInt = 3;
            TestUser.Stats.BaseStr = 3;
            TestUser.Stats.BaseDex = 3;
            TestUser.Stats.BaseCon = 3;
            TestUser.Stats.BaseWis = 3;
            TestUser.Stats.Level = 1;
            TestUser.Class = Class.Peasant;
        }

        public void Dispose()
        {
            var ep = World.DatastoreConnection.GetEndPoints();
            var server = World.DatastoreConnection.GetServer(ep.First().ToString());
            server.FlushDatabase(15);
        }
    }

    [CollectionDefinition("Hybrasyl")]
    public class HybrasylCollection : IClassFixture<HybrasylFixture> {}
}