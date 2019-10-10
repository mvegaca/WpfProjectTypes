using System;
using System.Collections;
using System.IO;
using CoreProject.Contracts.Services;
using Microsoft.Extensions.Options;
using RibbonProject.Contracts.Services;
using RibbonProject.Models;

namespace RibbonProject.Services
{
    public class PersistAndRestoreService : IPersistAndRestoreService
    {
        private readonly IFilesService _filesService;
        private readonly AppConfig _config;
        private readonly string _localAppData = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);

        public PersistAndRestoreService(IFilesService filesService, IOptions<AppConfig> config)
        {
            _filesService = filesService;
            _config = config.Value;
        }

        public void PersistData()
        {
            if (App.Current.Properties != null)
            {
                var folderPath = Path.Combine(_localAppData, _config.ConfigurationsFolder);
                var fileName = _config.AppPropertiesFileName;
                _filesService.Save(folderPath, fileName, App.Current.Properties);
            }
        }

        public void RestoreData()
        {
            var folderPath = Path.Combine(_localAppData, _config.ConfigurationsFolder);
            var fileName = _config.AppPropertiesFileName;
            var properties = _filesService.Read<IDictionary>(folderPath, fileName);
            if (properties != null)
            {
                foreach (DictionaryEntry property in properties)
                {
                    App.Current.Properties.Add(property.Key, property.Value);
                }
            }
        }
    }
}
