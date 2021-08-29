using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RockAndRoll
{
    public class ScriptThatDoesAFewThings : MonoBehaviour
    {
        private string _testString;
        
        private void Awake()
        {
            _testString = "1234567890";
            List<string> _myList = new List<string> { "a", "d", "r", "r", "f", "a", "r", "r" };
            Debug.Log($"Regular way: {_testString.Length}");
            Debug.Log($"Extension way: {_testString.LengthOf()}");

            Debug.Log($"Entries for generic: {"r".CountEntries(_myList)}");
            Debug.Log($"Entries via Linq: {"a".CountEntriesViaLinq(_myList)}");

        }

    }

    
}
