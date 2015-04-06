// $Id$
//
// Copyright 2008-2009 The AnkhSVN Project
//
//  Licensed under the Apache License, Version 2.0 (the "License");
//  you may not use this file except in compliance with the License.
//  You may obtain a copy of the License at
//
//    http://www.apache.org/licenses/LICENSE-2.0
//
//  Unless required by applicable law or agreed to in writing, software
//  distributed under the License is distributed on an "AS IS" BASIS,
//  WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//  See the License for the specific language governing permissions and
//  limitations under the License.

using System;
using Ankh.Commands;
using Ankh.Scc;

namespace Ankh.GitScc.StatusCache.Commands
{
    [GitCommand(AnkhCommand.GitCacheFinishTasks, AlwaysAvailable = true)]
    [GitCommand(AnkhCommand.TickRefreshGitItems, AlwaysAvailable = true)]
    public class FileStatusCleanup : ICommandHandler
    {
        public void OnUpdate(CommandUpdateEventArgs e)
        {
        }

        GitStatusCache _fileCache;
        IAnkhCommandService _commandService;

        public void OnExecute(CommandEventArgs e)
        {
            if (_commandService == null)
                _commandService = e.GetService<IAnkhCommandService>();
            if (_fileCache == null)
                _fileCache = e.GetService<GitStatusCache>(typeof(IGitStatusCache));

            _commandService.TockCommand(e.Command);

            if (e.Command == AnkhCommand.GitCacheFinishTasks)
                _fileCache.OnCleanup();
            else
                _fileCache.BroadcastChanges();
        }
    }
}
