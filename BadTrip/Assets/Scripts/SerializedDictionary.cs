using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.Rendering.DebugUI;

[Serializable]
public class Key_Value<K, V>
{
    public K key;
    public V value;

    public Key_Value(K key, V value)
    {
        this.key = key;
        this.value = value;
    }
}

[Serializable] // 이걸 해야 inspector 창에 등장
public class SerializedDictionary<K, V> : Dictionary<K, V>, ISerializationCallbackReceiver
{
    [SerializeField]
    List<Key_Value<K, V>> key_value = new();
    
    // 리스트를 딕셔너리로 만듦
    public void OnAfterDeserialize() // 역직렬화 후에 호출(역직렬화 후 딕셔너리가 리스트의 최신상태, 즉 이 둘의 일관성을 유지하기 위해 작동)
    {
        // 역직렬화를 하고 난 후 리스트를 다시 딕셔너리로 만들어야 함
        this.Clear();

        foreach (var pair in key_value)
        {
            var key = pair.key;

            if (this.ContainsKey(key)) // 인스펙터 창에서 추가를 할 때 이전에 추가한 키 값과 같은 값이 추가되어 같은 키 값이 있다고 인스펙터 창에 추가되지 않음.
            {
                // 인스펙터 창에 추가되지 않는 것을 수정하기 위해
                if (key is string)
                {
                    key = (K)(object)"[Default String Key]";
                }
                else
                {
                    key = default;
                }
            }
            this.Add(key, pair.value);
        }
    }

    // 딕셔너리를 리스트로 만듦
    public void OnBeforeSerialize() // 직렬화 전에 호출(직렬화 전에 딕셔너리와 리스트를 동기화)
    {
        // 직렬화 하기 전 딕셔너리를 리스트로 바꿔야 함.
        key_value.Clear();

        foreach (KeyValuePair<K, V> pair in this) // Dictionary를 상속받고 있어 dictionary 처럼 행동 가능. 그러므로 this를 사용하면 serializedDictionary의 모든 키-값을 순회하게 됨.
        {
            key_value.Add(new Key_Value<K, V>(pair.Key, pair.Value));
        }
    }
}
