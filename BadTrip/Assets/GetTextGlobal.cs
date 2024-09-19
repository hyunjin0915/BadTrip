// This code is part of the Fungus library (https://github.com/snozbot/fungus)
// It is released for free under the MIT open source license (https://github.com/snozbot/fungus/blob/master/LICENSE)

using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Serialization;

namespace Fungus
{
    /// <summary>
    /// Gets the text property from a UI Text object and stores it in a string variable.
    /// </summary>
    [CommandInfo("UI", 
                 "Get Text (Global)", 
                 "Gets the text property from a UI Text object and stores it in a string variable.")]
    [AddComponentMenu("")]
    public class GetTextGlobal : Command 
    {
        [Tooltip("Text object to get text value from")]
        [SerializeField] protected GameObject targetTextObject;

        [Tooltip("String variable to store the text value in")]
        
        [SerializeField] protected string stringVariable;

        #region Public members

        public override void OnEnter()
        {
            if (stringVariable == null)
            {
                Continue();
                return;
            }

            TextAdapter textAdapter = new TextAdapter();
            textAdapter.InitFromGameObject(targetTextObject);

            if (textAdapter.HasTextObject())
            {
                if (GlobalVariables.variables.ContainsKey(stringVariable))
                {
                    GlobalVariables.variables[stringVariable].SetValue(textAdapter.Text);
                }
            }

            Continue();
        }

        
       
        #endregion

        
    }
}