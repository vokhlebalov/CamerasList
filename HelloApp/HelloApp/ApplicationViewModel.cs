using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;
using Xamarin.Forms;
using System.Linq;
using System.Threading.Tasks;

namespace HelloApp
{
    public class ApplicationViewModel : INotifyPropertyChanged
    {
        bool initialized = false;
        private bool isBusy;

        public ObservableCollection<Camera> Cameras { get; set; }
        CameraService cameraService = new CameraService();
        public event PropertyChangedEventHandler PropertyChanged;

        public ICommand BackCommand { protected get; set; }

        public INavigation Navigation { get; set; }

        public bool IsBusy
        {
            get
            {
                return isBusy;
            }

            set
            {
                isBusy = value;
                OnPropertyChanged("IsBusy");
                OnPropertyChanged("IsLoaded");
            }
        }

        public bool IsLoaded
        {
            get { return !isBusy; }
        }



        public ApplicationViewModel()
        {
            Cameras = new ObservableCollection<Camera>();
            IsBusy = false;
            BackCommand = new Command(Back);
        }

        protected void OnPropertyChanged(string propName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propName));
            }
        }

        private void Back()
        {
            Navigation.PopAsync();
        }

        public async Task GetCameras()
        {
            if (initialized == true) return;
            IsBusy = true;
            IEnumerable<Camera> cameras = await cameraService.Get();

            while (Cameras.Any())
            {
                Cameras.RemoveAt(Cameras.Count - 1);
            }

            foreach (Camera camera in cameras)
            {
                Cameras.Add(camera);
            }

            IsBusy = false;
            initialized = true;
        }


    }
}
