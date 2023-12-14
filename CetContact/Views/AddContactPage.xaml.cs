using CetContact.Model;

namespace CetContact.Views;

public partial class AddContactPage : ContentPage
{
    ContactRepository contactRepository;
	public AddContactPage()
	{
		InitializeComponent();
        contactRepository = new ContactRepository();
	}

    private void BackButton_Clicked(object sender, EventArgs e)
    {
		//Shell.Current.GoToAsync($"//{nameof(ContactsPage)}");
        //Shell.Current.GoToAsync("//"+nameof(ContactsPage));
       
        Shell.Current.GoToAsync("..");


    }

    private async void SaveButton_Clicked(object sender, EventArgs e)
    {
        if (string.IsNullOrEmpty(NameEntry.Text) && string.IsNullOrEmpty(EmailEntry.Text))
        {
            // NameEntry.Text boş emailEntry.Text boş
            await DisplayAlert("Hata", "Kişi eklenemedi, isim ve e-mail kısmı boş geçilemez!", "Tamam");
        }
        else if(string.IsNullOrEmpty(EmailEntry.Text))
        {
            // emailEntry.Text boş
            await DisplayAlert("Hata", "Kişi eklenemedi, E-mail kısmı boş geçilemez!", "Tamam");
        }
        else if (string.IsNullOrEmpty(NameEntry.Text) )

        {
            // NameEntry.Text boş
            await DisplayAlert("Hata", "Kişi eklenemedi, İsim kısmı boş geçilemez!", "Tamam");
        }
        else {
            ContactInfo contact = new ContactInfo
            {
                Name = NameEntry.Text,
                Phone = PhoneEntry.Text,
                Address = AdressEntry.Text,
                Email = EmailEntry.Text,
            };
            await contactRepository.AddContact(contact);
            await Shell.Current.GoToAsync("..");
        }

        
    }
}