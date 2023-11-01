using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.IO;

namespace PasswordSaver;

public partial class MainWindowViewModel : ObservableObject
{
    private readonly string _filePath = "password.txt";
    private readonly PasswordHasher _hasher = new();

    [ObservableProperty] private string? _message;

    [ObservableProperty, 
        NotifyCanExecuteChangedFor(nameof(SavePasswordCommand)), 
        NotifyCanExecuteChangedFor(nameof(VerifyPasswordCommand))]
    private string? _password;

    [RelayCommand(CanExecute = nameof(CanSavePassword))]
    private void SavePassword()
    {
        var hashedPass = _hasher.HashPassword(Password!);

        File.WriteAllText(_filePath, hashedPass);
    }
    private bool CanSavePassword()
    {
        return Password?.Length > 0;
    }

    [RelayCommand(CanExecute = nameof(CanVerifyPassword))]
    private void VerifyPassword()
    {
        var hashedPass = File.ReadAllText(_filePath);
        var isPassOk = _hasher.VerifyPassword(Password!, hashedPass);

        Message = isPassOk switch
        {
            true => "Lozinka je ispravna!",
            false => "Lozinka je neispravna!"
        };
    }
    private bool CanVerifyPassword()
    {
        return Password?.Length > 0;
    }
}
