﻿/**
Copyright (c) 2020, 	Institut Curie, Institut Pasteur and CNRS
			Thomas BLanc, Mohamed El Beheiry, Jean Baptiste Masson, Bassam Hajj and Clement caporal
All rights reserved.

Redistribution and use in source and binary forms, with or without
modification, are permitted provided that the following conditions are met:
1. Redistributions of source code must retain the above copyright
   notice, this list of conditions and the following disclaimer.
2. Redistributions in binary form must reproduce the above copyright
   notice, this list of conditions and the following disclaimer in the
   documentation and/or other materials provided with the distribution.
3. All advertising materials mentioning features or use of this software
   must display the following acknowledgement:
   This product includes software developed by the Institut Curie, Insitut Pasteur and CNRS.
4. Neither the name of the Institut Curie, Insitut Pasteur and CNRS nor the
   names of its contributors may be used to endorse or promote products
   derived from this software without specific prior written permission.

THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDER ''AS IS'' AND ANY
EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT LIMITED TO, THE IMPLIED
WARRANTIES OF MERCHANTABILITY AND FITNESS FOR A PARTICULAR PURPOSE ARE
DISCLAIMED. IN NO EVENT SHALL THE COPYRIGHT HOLDER OR CONTRIBUTORS BE LIABLE
FOR ANY DIRECT, INDIRECT, INCIDENTAL, SPECIAL, EXEMPLARY, OR CONSEQUENTIAL 
DAMAGES (INCLUDING, BUT NOT LIMITED TO, PROCUREMENT OF SUBSTITUTE GOODS OR 
SERVICES; LOSS OF USE, DATA, OR PROFITS; OR BUSINESS INTERRUPTION) HOWEVER 
CAUSED AND ON ANY THEORY OF LIABILITY, WHETHER IN CONTRACT, STRICT LIABILITY,
OR TORT (INCLUDING NEGLIGENCE OR OTHERWISE) ARISING IN ANY WAY OUT OF THE 
USE OF THIS SOFTWARE, EVEN IF ADVISED OF THE POSSIBILITY OF SUCH DAMAGE.
**/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Data;

namespace DesktopInterface
{


    public class LinkClouds : MonoBehaviour
    {
        //public int id_to_associate;
        public int selected_id;
        public Button button;
        public CreateSelectionButtons selectionButtonManager;


        private void Start()
        {
            button = GetComponent<Button>();
            CloudUpdater.instance.OnCloudLinked += SwitchButtontoUnlink;
            CloudUpdater.instance.OnCloudUnlinked += SwitchButtontoLink;

            button.onClick.AddListener(Link);
        }

        public void Link()
        {
            List<int> cloudList = selectionButtonManager.GetIdsToggled();
            selected_id = CloudSelector.instance.GetID();


            CloudUpdater.instance.LinkClouds(cloudList);
        }

        public void Unlink()
        {
            List<int> cloudList = selectionButtonManager.GetIdsToggled();
            CloudUpdater.instance.UnlinkClouds(cloudList);

        }

        public void SwitchButtontoLink()
        {
            button.onClick.RemoveListener(Unlink);
            button.GetComponentInChildren<Text>().text = "Link";
            button.onClick.AddListener(Link);
        }

        public void SwitchButtontoUnlink()
        {
            button.onClick.RemoveListener(Link);
            button.GetComponentInChildren<Text>().text = "Unlink";
            button.onClick.AddListener(Unlink);
        }
    }
}