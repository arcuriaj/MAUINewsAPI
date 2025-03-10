using MAUITestAPI.Models;
using MAUITestAPI.Services;

namespace MAUITestAPI.Pages;

public partial class NewsHomePage : ContentPage
{
	public List<Article> ArticleList;
    public List<categories> CategoryList = new List<categories>()
   {
        new categories(){Name="World", ImageUrl = "world.png"},
        new categories(){Name = "Nation" , ImageUrl="nation.png"},
        new categories(){Name = "Business" , ImageUrl="business.png"},
        new categories(){Name = "Technology" , ImageUrl="technology.png"},
        new categories(){Name = "Entertainment", ImageUrl = "entertainment.png"},
        new categories(){Name = "Sports" , ImageUrl="sports.png"},
        new categories(){Name = "Science", ImageUrl= "science.png"},
        new categories(){Name = "Health", ImageUrl="health.png"},
    };
    public NewsHomePage()
	{
		InitializeComponent();
        GetBreakingNews();
		ArticleList = new List<Article>();
		CvCategories.ItemsSource = CategoryList;
	}

	private async Task GetBreakingNews() {
		var apiService = new APIService();
		var newsResult = await apiService.getNews("general");
		foreach (var article in newsResult.Articles) {
			ArticleList.Add(article);
		}
		CvNews.ItemsSource = ArticleList;
	}

    private void CvCategories_SelectionChanged(object sender, SelectionChangedEventArgs e) {
        var selectedItem = e.CurrentSelection.FirstOrDefault() as categories;
        if (selectedItem == null) return;
        Navigation.PushAsync(new NewsListPage(selectedItem));
        ((CollectionView)sender).SelectedItem = null;
    }

    private void CvNews_SelectionChanged(object sender, SelectionChangedEventArgs e) {

        var selectedItem = e.CurrentSelection.FirstOrDefault() as Article;
        if (selectedItem == null) return;
        Navigation.PushAsync(new NewsDetailsPage(selectedItem));
        ((CollectionView)sender).SelectedItem = null;
    }
}