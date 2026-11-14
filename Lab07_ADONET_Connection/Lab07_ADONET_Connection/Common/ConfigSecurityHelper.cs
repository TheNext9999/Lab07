using System;
using System.Configuration;

namespace Lab07_ADONET_Connection.Common
{
    public static class ConfigSecurityHelper
    {
        private const string Provider = "DataProtectionConfigurationProvider";

        public static bool IsConnectionStringProtected()
        {
            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            ConnectionStringsSection section = config.GetSection("connectionStrings") as ConnectionStringsSection;
            return section != null && section.SectionInformation.IsProtected;
        }

        public static void EncryptConnectionStrings()
        {
            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            ConnectionStringsSection section = config.GetSection("connectionStrings") as ConnectionStringsSection;
            if (section != null && !section.SectionInformation.IsProtected)
            {
                section.SectionInformation.ProtectSection(Provider);
                section.SectionInformation.ForceSave = true;
                config.Save(ConfigurationSaveMode.Full);
                ConfigurationManager.RefreshSection("connectionStrings");
                Logger.Info("Đã mã hóa mục connectionStrings trong App.config bằng DPAPI.");
            }
        }

        public static void DecryptConnectionStrings()
        {
            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            ConnectionStringsSection section = config.GetSection("connectionStrings") as ConnectionStringsSection;
            if (section != null && section.SectionInformation.IsProtected)
            {
                section.SectionInformation.UnprotectSection();
                section.SectionInformation.ForceSave = true;
                config.Save(ConfigurationSaveMode.Full);
                ConfigurationManager.RefreshSection("connectionStrings");
                Logger.Info("Đã giải mã mục connectionStrings trong App.config.");
            }
        }
    }
}