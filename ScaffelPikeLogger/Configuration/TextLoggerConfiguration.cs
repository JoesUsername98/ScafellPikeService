using System.Configuration;

namespace ScaffelPikeLogger.Configuration
{
  public class TextLoggerConfiguration : ConfigurationElement
  {
    #region Constructors
    public TextLoggerConfiguration()
    {
      s_propDirectory = new ConfigurationProperty("Directory", typeof(string), null, ConfigurationPropertyOptions.IsRequired);
      s_propFileName = new ConfigurationProperty("FileName", typeof(string), null, ConfigurationPropertyOptions.IsRequired);
      s_propFileExtension = new ConfigurationProperty("FileExtension",typeof(string),null,ConfigurationPropertyOptions.IsRequired);

      s_properties = new ConfigurationPropertyCollection();

      s_properties.Add(s_propDirectory);
      s_properties.Add(s_propFileName);
      s_properties.Add(s_propFileExtension);
    }
    #endregion

    #region Static Fields
    private static ConfigurationProperty s_propDirectory;
    private static ConfigurationProperty s_propFileName;
    private static ConfigurationProperty s_propFileExtension;

    private static ConfigurationPropertyCollection s_properties;
    #endregion


    #region Properties
    [ConfigurationProperty("Directory",IsRequired = true)]
    public string Directory 
    {
      get => (string)this["Directory"];
    }
    [ConfigurationProperty("FileName",IsRequired = true)]
    public string FileName 
    {
      get => (string)this["FileName"];
    }
    [ConfigurationProperty("FileExtension",IsRequired = true)]
    public string FileExtension 
    {
      get => (string)this["FileExtension"];
    }
    #endregion
  }
}
