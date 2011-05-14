using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;

namespace Picasa.Api
{
    public enum PicasaVisibility
    {
        /// <summary>
        /// Shows only public data.
        /// Does not require authentication. Most often used by an authenticated user to see only the publicly visible photos, corresponding to "View My Public Gallery" in the Picasa Web Albums GUI.
        /// </summary>
        PUBLIC,

        /// <summary>
        /// Shows only private data.
        /// Requires authentication. Only the owner can specify this value.
        /// </summary>
        PRIVATE,

        /// <summary>
        /// Shows all data, both public and private.
        /// Requires authentication. Default for the owner, and only the owner can specify this value.
        /// </summary>
        ALL,

        /// <summary>
        /// Shows all data the user has access to, including both all public photos or albums and any photos or albums that the owner has explicitly given the authenticated user rights to (using ACLs).
        /// Does not require authentication. Default for unauthenticated requests and for non-owners. For unauthenticated requests, this is the same as public. For authenticated non-owners, this returns the data that the owner has given them access to. For authenticated requests from the owner, this is the same as all.
        /// </summary>
        VISIBLE,


        PROTECTED,
    }
}
