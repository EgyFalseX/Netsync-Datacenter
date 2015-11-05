using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataCenter.Core
{
    public class MultiUpload : IDisposable, INotifyPropertyChanged
    {
        #region Properties
        private string _filename;
        public string Filename
        {
            get { return _filename; }
            set { _filename = value; OnPropertyChanged("Filename"); }
        }
        private string _filepath;
        public string Filepath
        {
            get { return _filepath; }
            set { _filepath = value; OnPropertyChanged("Filepath"); }
        }
        private int _filetype;
        public int Filetype
        {
            get { return _filetype; }
            set { _filetype = value; OnPropertyChanged("Filetype"); }
        }
        private bool _filelock;
        public bool Filelock
        {
            get { return _filelock; }
            set { _filelock = value; OnPropertyChanged("Filelock"); }
        }
        #endregion
        public event PropertyChangedEventHandler PropertyChanged;
        public MultiUpload()
        {

        }
        public MultiUpload(string filename, string filepath, int filetype, bool filelock)
        {
            _filename = filename;
            _filepath = filepath;
            _filetype = filetype;
            _filelock = filelock;
        }
        // Create the OnPropertyChanged method to raise the event 
        public void OnPropertyChanged(string name)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(name));
            }
        }
        public void Dispose()
        {
        }
    }
}
