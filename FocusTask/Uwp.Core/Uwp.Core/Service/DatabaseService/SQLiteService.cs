using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Uwp.SQLite.Model;

namespace Uwp.Core.Service
{
    public class SQLiteService : IDataService
    {
        private static DataContext _db = new DataContext();
        public static DataContext Db { get { return _db; } }

        public void AddMission(Mission mission)
        {
            Db.Missions.Add(mission);
            SaveChanges();
        }

        public void AddProject(Project project)
        {
            Db.Projects.Add(project);
            SaveChanges();
        }

        public void AddSubMission(SubMission submission)
        {
            Db.Submissions.Add(submission);
            SaveChanges();
        }

        public ObservableCollection<Mission> GetMissions()
        {
            return new ObservableCollection<Mission>(Db.Missions
                .Include(x=>x.Project)
                .ToList());
        }

        public ObservableCollection<Project> GetProjects()
        {
            return new ObservableCollection<Project>(Db.Projects
                .Include(x=>x.Missions)
                .ToList());
        }

        public ObservableCollection<SubMission> GetSubMissions()
        {
            return new ObservableCollection<SubMission>(Db.Submissions.ToList());
        }

        public void RemoveMission(Mission mission)
        {
            Db.Missions.Remove(mission);
            SaveChanges();
        }

        public void RemoveProject(Project project)
        {
            Db.Projects.Remove(project);
            SaveChanges();
        }

        public void RemoveSubMission(SubMission mission)
        {
            Db.Submissions.Remove(mission);
        }

        public void SaveChanges()
        {
            Db.SaveChanges();
        }

        public async Task SaveChangesAsync()
        {
            await Db.SaveChangesAsync();
        }
    }
}
