using System.Configuration;

namespace ScafellPikeLogger.Configuration
{

  public class LoggerConfiguration : ConfigurationSection
  {
    #region Constructors

    static LoggerConfiguration()
    {
      s_propTextLoggerConfiguration = new ConfigurationProperty(
          "TextLoggerConfiguration",
          typeof(TextLoggerConfiguration),
          null,
          ConfigurationPropertyOptions.IsRequired
      );

      s_properties = new ConfigurationPropertyCollection();

      s_properties.Add(s_propTextLoggerConfiguration);
    }
    #endregion

    #region Static Fields
    private static ConfigurationProperty s_propTextLoggerConfiguration;
    private static ConfigurationPropertyCollection s_properties;
    #endregion

    [ConfigurationProperty("LoggerType")]
    public LoggerType LoggerType 
    { 
      get =>(LoggerType)this["LoggerType"]; 
    }

    #region Properties
    [ConfigurationProperty("TextLoggerConfiguration")]
    public TextLoggerConfiguration TextLoggerConfiguration 
    {
      get =>(TextLoggerConfiguration)base["TextLoggerConfiguration"];
    }
    #endregion
  }
}
