﻿using Android.Content;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using Prism.Services;
using Refit;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Xamarin.Forms;
using Xamarin.Essentials;

namespace TaskT6.ViewModels
{
   public  class PageLoginViewModel : BindableBase
    {
        private string etremail;
        private string etrpass;
        private string uriimage;
       
        private INavigationService _navigationService;  
        IPageDialogService dialogService;
      
        private List<string> _list;
        public List<string> List
        {
            get { return _list; }
            set { SetProperty(ref _list, value); }
        }
        private ObservableCollection<User> _emaillist;
        public ObservableCollection<User> Emaillist
        {
            get { return _emaillist; }
            set { SetProperty(ref _emaillist, value); }
        }
        private DelegateCommand _btnLoginFB;
        public DelegateCommand BtnLoginFB => _btnLoginFB ??
          (_btnLoginFB = new DelegateCommand(ActionLoginFB));

        private void ActionLoginFB()
        {
            UserInfo.Email = "Shanna@melissa.tv";
            _navigationService.NavigateAsync("ProviderLoginPage", useModalNavigation: true);
        }

        public string Etrpass { get => etrpass; set => etrpass = value; }
        private DelegateCommand _btnlogincommand;
        public DelegateCommand Btnlogincommand => _btnlogincommand ??            
          (_btnlogincommand = new DelegateCommand(ActionLogin));

        public string Uriimage { get => uriimage; set => uriimage = value; }
        public string EtrEmail { get => etremail; set => etremail = value; }

        private void ActionLogin()
        {
            if(Connectivity.NetworkAccess != NetworkAccess.Internet)
            {
                dialogService.DisplayAlertAsync("Alert", "No Internet", "Cancel");
                return;
            }
           if(EtrEmail.Length>= 8 && Etrpass.Length>= 8 )
            {
              

                UserInfo.Email = EtrEmail;
                UserInfo.Pass = Etrpass;
                _navigationService.NavigateAsync("PageMaster", useModalNavigation: true);
             


            }
           else
            {
                dialogService.DisplayAlertAsync("Alert", "You Login Fail", "OK");
            }
        }

        public PageLoginViewModel(IPageDialogService _dialogService, INavigationService navigationService)
        {
            dialogService = _dialogService;
            _navigationService = navigationService;
            Uriimage = "iconlogin.jpg";
            EtrEmail = "Shanna@melissa.tv";
            Etrpass = "12345678";
            // GetusernameAsync();
            GetemailAsync();
        }
        public async void GetemailAsync()
        {
            var apiResponse = RestService.For<IGetDataApi>("https://jsonplaceholder.typicode.com");
            var apiuser = await apiResponse.GetUserName();
            Emaillist = apiuser;
        }
     
    }
}
