using System;
using System.Collections.Generic;
using System.Text;

namespace Doppler
{
    class DopplerPluginContext : IDopplerPluginContext
    {
        private string _filename;
        private Uri _url;

        #region IDopplerPluginContext Members

        public string Filename
        {
            get
            {
                return _filename;
            }
            set
            {
                _filename = value;
            }
        }

        public Uri Url
        {
            get
            {
                return _url;
            }
            set
            {
                _url = value;
            }
        }

        #endregion
    }
}
