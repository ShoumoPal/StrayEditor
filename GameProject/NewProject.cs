using StrayEditor.Utilities;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace StrayEditor.GameProject
{
    [DataContract]
    public class ProjectTemplate
    {
        [DataMember]
        public string ProjectType { get; set; }
        [DataMember]
        public string ProjectFile { get; set; }
        [DataMember]
        public List<string> Folders { get; set; }
    }
    class NewProject : ViewModelBase
    {
        // TODO : get path from installation location
        private readonly string _templatePath = @"..\..\StrayEditor\Project Templates";
        private string _name = "New Project";

        public string Name
        {
            get => _name;
            set
            {
                if (_name != value)
                {
                    _name = value;
                    OnPropertyChanged(nameof(Name));
                }
            }
        }

        private string _path = $@"{Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)}\StrayProject\";

        public string Path
        {
            get => _path;
            set
            {
                if (_path != value)
                {
                    _path = value;
                    OnPropertyChanged(nameof(Path));
                }
            }
        }

        public NewProject()
        {
            try
            {
                var templateFiles = Directory.GetFiles(_templatePath, "template.xml", searchOption: SearchOption.AllDirectories);
                Debug.Assert(templateFiles.Any());
                foreach (var file in templateFiles)
                {
                    var template = new ProjectTemplate()
                    {
                        ProjectType = "Empty Project",
                        ProjectFile = "project.stray",
                        Folders = new List<string> { ".Stray", "Content", "GameCode" }
                    };

                    Serializer.ToFile(template, file);
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
                // TODO: log errors
            }
        }
    } 
}
