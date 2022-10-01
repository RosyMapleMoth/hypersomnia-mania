using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lifeCounter : MonoBehaviour
{
    public Transform LifeContainer;
    public GameObject LifePrefab;


    public void addLife()
    {
        Instantiate(LifePrefab);
        LifePrefab.transform.SetParent(LifeContainer);
    }

    public void removeLife()
    {
        if (LifeContainer.childCount <= 0)
        {
            throw new lifeCounterException("No lives to remove");
        }
        else
        {
            Destroy(LifeContainer.GetChild(0));
        }
    }

    public void init(int LivesToSet)
    {
        for (int i = 0 ; i < LivesToSet; i ++)
        {
            addLife();
        }
    }


    public class lifeCounterException : System.Exception
    {
        public lifeCounterException() { }
        public lifeCounterException(string message) : base(message) { }
        public lifeCounterException(string message, System.Exception inner) : base(message, inner) { }
        protected lifeCounterException(
            System.Runtime.Serialization.SerializationInfo info,
            System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}
