using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Uwp.SQLite.Model;

namespace Uwp.Core.Service
{
    public interface IDataService
    {
        void SaveChanges();
        Task SaveChangesAsync();

        ObservableCollection<Project> GetProjects();
        void AddProject(Project project);
        void RemoveProject(Project project);

        ObservableCollection<Mission> GetMissions();
        void AddMission(Mission mission);
        void RemoveMission(Mission mission);

        ObservableCollection<SubMission> GetSubMissions();
        void AddSubMission(SubMission submission);
        void RemoveSubMission(SubMission mission);
    }
}
