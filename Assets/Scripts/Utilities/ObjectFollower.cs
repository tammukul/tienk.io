﻿//
//  Copyright (c) 2017  FederationOfCoders.org
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
//     http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
//

using UnityEngine;

namespace Tienkio.Utilities {
    public class ObjectFollower : MonoBehaviour {
        public Transform follow;
        public Vector3 positionOffset, rotationOffset;

        new Transform transform, camera;

        void Awake() {
            transform = base.transform;
        }

        void Update() {
            if (camera == null) camera = UnityEngine.Camera.main.transform;

            if (follow != null) transform.position = camera.rotation * positionOffset + follow.position;
            transform.rotation = camera.rotation * Quaternion.Euler(rotationOffset);
        }
    }
}
