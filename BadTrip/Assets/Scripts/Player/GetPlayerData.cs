using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using UnityEngine.TextCore.LowLevel;

namespace Fungus
{
    [CommandInfo("Custom",
                     "GetPlayerData",
                     "PlayerDataSO 가져오기")]
    [AddComponentMenu("")]
    public class GetPlayerData : Command
    {
        [SerializeField] protected PlayerDataSO playerDataSO;
        [SerializeField] protected string paramName = "";

        [VariableProperty(typeof(BooleanVariable),
                          typeof(IntegerVariable),
                          typeof(FloatVariable),
                          typeof(StringVariable))]
        [SerializeField] protected Variable variable;

        public override void OnEnter()
        {
            FieldInfo fieldInfo = playerDataSO.GetType().GetField(paramName);

            if (fieldInfo != null)
            {
                System.Type variableType = variable.GetType();

                if (variableType == typeof(BooleanVariable))
                {
                    BooleanVariable booleanVariable = variable as BooleanVariable;
                    if (booleanVariable != null)
                    {
                        booleanVariable.Value = (bool)fieldInfo.GetValue(playerDataSO);
                    }
                }
                else if (variableType == typeof(IntegerVariable))
                {
                    IntegerVariable integerVariable = variable as IntegerVariable;
                    if (integerVariable != null)
                    {
                        integerVariable.Value = (int)fieldInfo.GetValue(playerDataSO);
                    }
                }
                else if (variableType == typeof(FloatVariable))
                {
                    FloatVariable floatVariable = variable as FloatVariable;
                    if (floatVariable != null)
                    {
                        floatVariable.Value = (float)fieldInfo.GetValue(playerDataSO);
                    }
                }
                else if (variableType == typeof(StringVariable))
                {
                    StringVariable stringVariable = variable as StringVariable;
                    if (stringVariable != null)
                    {
                        stringVariable.Value = fieldInfo.GetValue(playerDataSO).ToString();
                    }
                }
            }

            /*foreach (KeyValuePair<string, Variable> v in GlobalVariables.variables)
            {
                Debug.Log(v.Value.GetValue());
                v.Value.SetValue("아아아아");
                Debug.Log(v.Value.GetValue());
            }*/

            //Debug.Log(GlobalVariables.variables["playerName"].GetValue());

            Continue();
        }
    }
}
