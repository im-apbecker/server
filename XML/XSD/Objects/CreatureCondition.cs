// ------------------------------------------------------------------------------
//  <auto-generated>
//    Generated by Xsd2Code++. Version 6.0.20.0. www.xsd2code.com
//  </auto-generated>
// ------------------------------------------------------------------------------
#pragma warning disable
namespace Hybrasyl.Xml
{
using System;
using System.Diagnostics;
using System.Xml.Serialization;
using System.Runtime.Serialization;
using System.Collections;
using System.Xml.Schema;
using System.ComponentModel;
using System.Xml;
using System.IO;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

[System.FlagsAttribute()]
[System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.8.4161.0")]
[Serializable]
[XmlTypeAttribute(AnonymousType=true, Namespace="http://www.hybrasyl.com/XML/Hybrasyl/2020-02")]
public enum CreatureCondition
{
    Freeze = 1,
    Sleep = 2,
    Paralyze = 4,
    Blind = 8,
    Coma = 16,
    Poison = 32,
    Mist = 64,
    Regen = 128,
    Sight = 256,
    Invisible = 512,
    Mute = 1024,
    ReflectPhysical = 2048,
    ReflectMagical = 4096,
    Invulnerable = 8192,
    Charm = 16384,
    IncreaseDamage = 32768,
    ReduceDamage = 65536,
    AbsorbSpell = 131072,
    ProhibitItemUse = 262144,
    ProhibitEquipChange = 524288,
    ProhibitSpeech = 1048576,
    ProhibitWhisper = 2097152,
    ProhibitShout = 4194304,
}
}
#pragma warning restore
