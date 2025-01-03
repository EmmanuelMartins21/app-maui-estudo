using Android.App;
using Android.Content.PM;
using Android.OS;

namespace app_maui_estudo
{
    [Activity(Theme = "@style/Maui.SplashTheme", MainLauncher = true, LaunchMode = LaunchMode.SingleTop, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation | ConfigChanges.UiMode | ConfigChanges.ScreenLayout | ConfigChanges.SmallestScreenSize | ConfigChanges.Density)]
    public class MainActivity : MauiAppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Verifique se o Intent tem extras
            if (Intent?.Extras != null)
            {
                string? extraValue = Intent.GetStringExtra("extraKey");
                if (!string.IsNullOrEmpty(extraValue))
                {
                    // Armazene ou use o valor do extra no app
                    Preferences.Set("extraKey", extraValue);
                }
            }
        }
    }
}
