using MAUITestAPI.Models;

namespace MAUITestAPI.Pages;

public partial class NewsDetailsPage : ContentPage
{
	public NewsDetailsPage(Article article)
	{
		InitializeComponent();
		lblTitle.Text = article.Title;
		lblContent.Text = article.Content;
		imgArticle.Source = article.Image;
	}
}