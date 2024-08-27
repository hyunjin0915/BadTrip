using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

namespace Fungus
{
    [CommandInfo("Custom",
                     "SetPlayerData",
                     "PlayerDataSO ¼³Á¤")]
    [AddComponentMenu("")]
    public class SetPlayerData : Command
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
                fieldInfo.SetValue(playerDataSO, variable.GetValue());
            }

            Continue();
        }


    }
}

