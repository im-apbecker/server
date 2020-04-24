// ------------------------------------------------------------------------------
//  <auto-generated>
//    Generated by Xsd2Code++. Version 5.1.46.0. www.xsd2code.com
//  </auto-generated>
// ------------------------------------------------------------------------------
#pragma warning disable
namespace Hybrasyl.Xml
{
using System;
using System.Diagnostics;
using System.Xml.Serialization;
using System.Collections;
using System.Xml.Schema;
using System.ComponentModel;
using System.IO;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.Xml;
using System.Collections.Generic;

[System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.8.3752.0")]
[Serializable]
[DebuggerStepThrough]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[XmlTypeAttribute(Namespace="http://www.hybrasyl.com/XML/Hybrasyl/2020-02")]
public partial class Use
{
    #region Private fields
    private string _script;
    private ItemUseTeleport _teleport;
    private ItemUsePlayerEffect _playerEffect;
    private ItemUseEffect _effect;
    private ItemUseSound _sound;
    private bool _consumed;
    private static XmlSerializer serializer;
    #endregion
    
    public Use()
    {
        _consumed = true;
    }
    
    public string Script
    {
        get
        {
            return _script;
        }
        set
        {
            _script = value;
        }
    }
    
    public ItemUseTeleport Teleport
    {
        get
        {
            return _teleport;
        }
        set
        {
            _teleport = value;
        }
    }
    
    public ItemUsePlayerEffect PlayerEffect
    {
        get
        {
            return _playerEffect;
        }
        set
        {
            _playerEffect = value;
        }
    }
    
    public ItemUseEffect Effect
    {
        get
        {
            return _effect;
        }
        set
        {
            _effect = value;
        }
    }
    
    public ItemUseSound Sound
    {
        get
        {
            return _sound;
        }
        set
        {
            _sound = value;
        }
    }
    
    [XmlAttribute]
    [DefaultValue(true)]
    public bool Consumed
    {
        get
        {
            return _consumed;
        }
        set
        {
            _consumed = value;
        }
    }
    
    private static XmlSerializer Serializer
    {
        get
        {
            if ((serializer == null))
            {
                serializer = new XmlSerializerFactory().CreateSerializer(typeof(Use));
            }
            return serializer;
        }
    }
    
    #region Serialize/Deserialize
    /// <summary>
    /// Serializes current Use object into an XML string
    /// </summary>
    /// <returns>string XML value</returns>
    public virtual string Serialize()
    {
        StreamReader streamReader = null;
        MemoryStream memoryStream = null;
        try
        {
            memoryStream = new MemoryStream();
            System.Xml.XmlWriterSettings xmlWriterSettings = new System.Xml.XmlWriterSettings();
            xmlWriterSettings.Indent = true;
            xmlWriterSettings.IndentChars = "  ";
            System.Xml.XmlWriter xmlWriter = XmlWriter.Create(memoryStream, xmlWriterSettings);
            Serializer.Serialize(xmlWriter, this);
            memoryStream.Seek(0, SeekOrigin.Begin);
            streamReader = new StreamReader(memoryStream);
            return streamReader.ReadToEnd();
        }
        finally
        {
            if ((streamReader != null))
            {
                streamReader.Dispose();
            }
            if ((memoryStream != null))
            {
                memoryStream.Dispose();
            }
        }
    }
    
    /// <summary>
    /// Deserializes workflow markup into an Use object
    /// </summary>
    /// <param name="input">string workflow markup to deserialize</param>
    /// <param name="obj">Output Use object</param>
    /// <param name="exception">output Exception value if deserialize failed</param>
    /// <returns>true if this Serializer can deserialize the object; otherwise, false</returns>
    public static bool Deserialize(string input, out Use obj, out Exception exception)
    {
        exception = null;
        obj = default(Use);
        try
        {
            obj = Deserialize(input);
            return true;
        }
        catch (Exception ex)
        {
            exception = ex;
            return false;
        }
    }
    
    public static bool Deserialize(string input, out Use obj)
    {
        Exception exception = null;
        return Deserialize(input, out obj, out exception);
    }
    
    public static Use Deserialize(string input)
    {
        StringReader stringReader = null;
        try
        {
            stringReader = new StringReader(input);
            return ((Use)(Serializer.Deserialize(XmlReader.Create(stringReader))));
        }
        finally
        {
            if ((stringReader != null))
            {
                stringReader.Dispose();
            }
        }
    }
    
    public static Use Deserialize(Stream s)
    {
        return ((Use)(Serializer.Deserialize(s)));
    }
    #endregion
    
    /// <summary>
    /// Serializes current Use object into file
    /// </summary>
    /// <param name="fileName">full path of outupt xml file</param>
    /// <param name="exception">output Exception value if failed</param>
    /// <returns>true if can serialize and save into file; otherwise, false</returns>
    public virtual bool SaveToFile(string fileName, out Exception exception)
    {
        exception = null;
        try
        {
            SaveToFile(fileName);
            return true;
        }
        catch (Exception e)
        {
            exception = e;
            return false;
        }
    }
    
    public virtual void SaveToFile(string fileName)
    {
        StreamWriter streamWriter = null;
        try
        {
            string xmlString = Serialize();
            FileInfo xmlFile = new FileInfo(fileName);
            streamWriter = xmlFile.CreateText();
            streamWriter.WriteLine(xmlString);
            streamWriter.Close();
        }
        finally
        {
            if ((streamWriter != null))
            {
                streamWriter.Dispose();
            }
        }
    }
    
    /// <summary>
    /// Deserializes xml markup from file into an Use object
    /// </summary>
    /// <param name="fileName">string xml file to load and deserialize</param>
    /// <param name="obj">Output Use object</param>
    /// <param name="exception">output Exception value if deserialize failed</param>
    /// <returns>true if this Serializer can deserialize the object; otherwise, false</returns>
    public static bool LoadFromFile(string fileName, out Use obj, out Exception exception)
    {
        exception = null;
        obj = default(Use);
        try
        {
            obj = LoadFromFile(fileName);
            return true;
        }
        catch (Exception ex)
        {
            exception = ex;
            return false;
        }
    }
    
    public static bool LoadFromFile(string fileName, out Use obj)
    {
        Exception exception = null;
        return LoadFromFile(fileName, out obj, out exception);
    }
    
    public static Use LoadFromFile(string fileName)
    {
        FileStream file = null;
        StreamReader sr = null;
        try
        {
            file = new FileStream(fileName, FileMode.Open, FileAccess.Read);
            sr = new StreamReader(file);
            string xmlString = sr.ReadToEnd();
            sr.Close();
            file.Close();
            return Deserialize(xmlString);
        }
        finally
        {
            if ((file != null))
            {
                file.Dispose();
            }
            if ((sr != null))
            {
                sr.Dispose();
            }
        }
    }
}
}
#pragma warning restore
