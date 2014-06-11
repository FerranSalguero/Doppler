using System;
using System.Collections.Generic;
using System.Text;

namespace Doppler
{
    
    public interface IDopplerPlugin
    {
        bool BeforeFileDownload(IDopplerPluginContext context);
        bool AfterFileDownload(IDopplerPluginContext context);
        bool BeforeFeedAdd(IDopplerPluginContext context);
        bool AfterFeedAdd(IDopplerPluginContext context);
    }

    public interface IDopplerPluginContext
    {
        string Filename { get;set;}
        Uri Url { get;set;}
    }

}

