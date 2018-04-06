﻿#region Greenshot GNU General Public License

// Greenshot - a free and open source screenshot tool
// Copyright (C) 2007-2018 Thomas Braun, Jens Klingen, Robin Krom
// 
// For more information see: http://getgreenshot.org/
// The Greenshot project is hosted on GitHub https://github.com/greenshot/greenshot
// 
// This program is free software: you can redistribute it and/or modify
// it under the terms of the GNU General Public License as published by
// the Free Software Foundation, either version 1 of the License, or
// (at your option) any later version.
// 
// This program is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// GNU General Public License for more details.
// 
// You should have received a copy of the GNU General Public License
// along with this program.  If not, see <http://www.gnu.org/licenses/>.

#endregion

#region Usings

using System.ComponentModel;
using Dapplo.HttpExtensions.OAuth;
using Dapplo.Ini;
using Dapplo.InterfaceImpl.Extensions;
using Greenshot.Addons.Core.Enums;

#endregion

namespace Greenshot.Addon.OneDrive
{
    [IniSection("OneDrive")]
    [Description("Greenshot OneDrive Addon configuration")]
    public interface IOneDriveConfiguration : IIniSection, IOAuth2Token, ITransactionalProperties, INotifyPropertyChanged
    {
        [Description("What file type to use for uploading")]
        [DefaultValue("png")]
        OutputFormats UploadFormat { get; set; }

        [Description("JPEG file save quality in %.")]
        [DefaultValue("80")]
        int UploadJpegQuality { get; set; }

        [Description("After upload copy OneDrive link to clipboard.")]
        [DefaultValue("true")]
        bool AfterUploadLinkToClipBoard { get; set; }

        [Description("Should the link be sharable or restricted.")]
        [DefaultValue(OneDriveLinkType.@private)]
        OneDriveLinkType LinkType { get; set; }

        [Description("The OneDrive refresh token")]
        string RefreshToken { get; set; }

        [Description("Reduce color amount of the uploaded image to 256")]
        [DefaultValue(false)]
        bool UploadReduceColors { get; set; }

        [Description("Filename for the OneDrive upload")]
        [DefaultValue("${capturetime:d\"yyyyMMdd-HHmm\"}")]
        string FilenamePattern { get; set; }

        /// <summary>
        ///     Not stored, but read so people could theoretically specify their own Client ID.
        /// </summary>
        [IniPropertyBehavior(Write = false)]
        [DefaultValue("@credentials_onedrive_client_id@")]
        string ClientId { get; set; }

        /// <summary>
        ///     Not stored, but read so people could theoretically specify their own client secret.
        /// </summary>
        [IniPropertyBehavior(Write = false)]
        [DefaultValue("@credentials_onedrive_client_secret@")]
        string ClientSecret { get; set; }
    }
}