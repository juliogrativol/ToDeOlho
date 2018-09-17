using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace Modelo
{
    public sealed class Repository
    {
        private static ObservableCollection<Publicacao> Items = new ObservableCollection<Publicacao>();
        private static Repository instance = null;

        public static Repository Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Repository();
                }
                return instance;
            }
        }

        public ObservableCollection<Publicacao>  getItems()
        {
            return Items;
        }

        public void addItems(Publicacao publicacao)
        {
            Items.Add(publicacao);
        }
    }
}
