using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sharing
{
    public class SideMenuDesignModel : SideMenuViewModel
    {
        public static SideMenuDesignModel Instance => new SideMenuDesignModel();

        public SideMenuDesignModel()
        {
            Username = new TextEntryViewModel
            {
                Label = "Username",
                OriginalText = "DesignTimeName"
            };
        }
    }
}
