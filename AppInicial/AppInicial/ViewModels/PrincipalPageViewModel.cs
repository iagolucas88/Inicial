using AppInicial.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace AppInicial.ViewModels
{
    public class PrincipalPageViewModel
    {

        public ObservableCollection<Pessoa> ListaPessoas { get; set; }

        public PrincipalPageViewModel()
        {
            ListaPessoas = new ObservableCollection<Pessoa>();
            ListaPessoas.Add(new Pessoa { Id = 0, Nome = "Gia",CPF = "12345" });
        }
    }
}
