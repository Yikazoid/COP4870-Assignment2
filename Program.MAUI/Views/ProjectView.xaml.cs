using Program.MAUI.ViewModels;

namespace Program.MAUI.Views;

[QueryProperty(nameof(ClientId), "clientId")]
public partial class ProjectView : ContentPage
{
    public int ClientId { get; set; }
	public ProjectView()
	{
		InitializeComponent();
		BindingContext = new ProjectViewViewModel();
	}

    private void SearchClicked(object sender, EventArgs e)
    {
        (BindingContext as ProjectViewViewModel).Search();
    }

    private void RefreshClicked(object sender, EventArgs e)
    {
        (BindingContext as ProjectViewViewModel).Refresh();
    }

    private void AddClicked(object sender, EventArgs e)
    {
        (BindingContext as ProjectViewViewModel).AddProject(Shell.Current);
    }

    private void EditClicked(object sender, EventArgs e)
    {
        (BindingContext as ProjectViewViewModel).EditProject(Shell.Current);
    }

    private void DeleteClicked(object sender, EventArgs e)
    {
        (BindingContext as ProjectViewViewModel).Delete();
    }

    private void CancelClicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("//Client");
    }
}