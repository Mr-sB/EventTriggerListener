using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameUtil.Example
{
    public class ExampleTest : MonoBehaviour
    {
        public void OnClick(string message)
        {
            Debug.Log("on click:" + message);
        }
    }
}
