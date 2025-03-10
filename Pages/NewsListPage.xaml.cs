using MAUITestAPI.Models;
using MAUITestAPI.Services;

namespace MAUITestAPI.Pages;

public partial class NewsListPage : ContentPage {
    public List<Article> ArticleList;
    public NewsListPage(categories category)
	{
		InitializeComponent();
        titlePage.Title = category.Name;
        GetBreakingNews(category);
        ArticleList = new List<Article>();
    }

    private async Task GetBreakingNews(categories c) {
        var apiService = new APIService();
        var newsResult = await apiService.getNews(c.Name);
        foreach (var article in newsResult.Articles) {
            ArticleList.Add(article);
        }
        CvNewsCategory.ItemsSource = ArticleList;
    }

    private void CvNewsCategory_SelectionChanged(object sender, SelectionChangedEventArgs e) {
        var selectedItem = e.CurrentSelection.FirstOrDefault() as Article;
        if (selectedItem == null) return;
        Navigation.PushAsync(new NewsDetailsPage(selectedItem));
        ((CollectionView)sender).SelectedItem = null;
    }
}