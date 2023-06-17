using Program.Library.Models;
using Program.Library.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Program.MAUI.ViewModels;

public class ProjectViewViewModel : INotifyPropertyChanged
{
    public ObservableCollection<Project> Projects
    {
        get
        {
            if (string.IsNullOrEmpty(Query))
            {
                return new ObservableCollection<Project>(ProjectService.Current.ProjectList);
            }
            return new ObservableCollection<Project>(ProjectService.Current.Search(Query));
        }
    }

    public string Query { get; set; }
    public Project SelectedProject { get; set; }
    public int ClientId { get; set; }

    public void Search()
    {
        NotifyPropertyChanged("Projects");
    }

    public void Refresh()
    {
        Query = string.Empty;
        NotifyPropertyChanged(nameof(Query));
        NotifyPropertyChanged("Projects");
    }

    public void AddProject(Shell s)
    {
        s.GoToAsync($"//ProjectDetail?projectId=0?clientId=clientId");
    }

    public void EditProject(Shell s)
    {
        var idParam = SelectedProject?.Id ?? 0;
        s.GoToAsync($"//ProjectDetail?projectId={idParam}");
    }

    public void Delete()
    {
        if(SelectedProject == null)
        {
            return;
        }
        ProjectService.Current.Delete(SelectedProject);
        NotifyPropertyChanged("Projects");
    }

    public event PropertyChangedEventHandler PropertyChanged;
    private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
