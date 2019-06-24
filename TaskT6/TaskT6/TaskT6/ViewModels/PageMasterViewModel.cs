using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;

namespace TaskT6.ViewModels
{
    public class PageMasterViewModel : BindableBase
    {
        INavigationService _navigationService;
        private DelegateCommand _btninfor;
        private DelegateCommand _btnlistimg;
        private DelegateCommand _btnlogout;
        private string _email;
        public string Email
        {
            get { return _email; }
            set { SetProperty(ref _email, value); }
        }
        public PageMasterViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
            if (FacebookAuth.loginfb == true)
            {
                Email = FacebookAuth.User.Name;
                Uriimage = FacebookAuth.User.Picture.Data.Url;
            }
            else
            {
                Email = UserInfo.Email;
                Uriimage = "iconlogin.jpg";
            }

        }
        private string _uriimage;
        public string Uriimage
        {
            get { return _uriimage; }
            set { SetProperty(ref _uriimage, value); }
        }
        public DelegateCommand Btninfor => _btninfor ?? (_btninfor = new DelegateCommand(MovePageInfor));

        public DelegateCommand Btnlistimg => _btnlistimg ?? (_btnlistimg = new DelegateCommand(MovePageListImg));

        public DelegateCommand Btnlogout => _btnlogout ?? (_btnlogout = new DelegateCommand(BtnLogout));

        private void BtnLogout()
        {
            Reset();
            _navigationService.NavigateAsync("PageLogin", useModalNavigation: true);
        }
        void Reset()
        {
            if (FacebookAuth.loginfb == true)
            {
                FacebookAuth.User.Name = "";
                FacebookAuth.User.Id = "";
                FacebookAuth.User.Picture.Data.Url = "";
                FacebookAuth.loginfb = false;
            }
            UserInfo.Name = "";
            UserInfo.Email = "";
        }
        private void MovePageListImg()
        {
            _navigationService.NavigateAsync("PageListImage");
        }

        private void MovePageInfor()
        {
            _navigationService.NavigateAsync("PageInforUser");
        }
    }
}
