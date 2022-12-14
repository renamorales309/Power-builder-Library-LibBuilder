// project=PBDotNet.Core, file=Library.cs, create=09:16 Copyright (c) 2021 Timeline
// Financials GmbH & Co. KG. All rights reserved.
using PBDotNet.Core.common;
using PBDotNet.Core.orca;
using System.IO;

namespace PBDotNet.Core.pbuilder
{
    /// <summary>
    /// pb library
    /// </summary>
    public class Library : ILibrary
    {
        #region private

        private string dir;
        private string file;
        private Orca orca = null;

        #endregion private

        #region properties

        public string Dir
        {
            get
            {
                return dir;
            }
        }

        public string File
        {
            get
            {
                return file;
            }
        }

        public string FilePath
        {
            get
            {
                return Path.Combine(Dir, File);
            }
        }

        #endregion properties

        public ILibEntry[] EntryList
        {
            get
            {
                return orca.DirLibrary(FilePath).ToArray();
            }
        }

        /// <summary>
        /// constructor
        /// </summary>
        /// <param name="file">path to lib</param>
        /// <param name="version">PB version</param>
        public Library(string file, Orca.Version version)
        {
            this.orca = new Orca(version);
            this.dir = Path.GetDirectoryName(file);
            this.file = Path.GetFileName(file);
        }
    }
}