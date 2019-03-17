using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;


namespace StarProject.Aquarius
{
    public class InstantiateTest : MonoBehaviour
    {
        public GameObject target;     //生成するゲームオブジェクト
        private Vector3 targetPosi;   //

        public GameObject assistFairy;  //

        public GameObject jadge;    //
        public ParticleSystem snow; //
        private Vector3 snowPosi;   //
        float particleStop = 2.0f;  //

        void Awake()
        {
            snow.gameObject.SetActive(false);
        }

        void Update()
        {
            //Qを押したら
            if (Input.GetKeyDown(KeyCode.Q) && snow.isStopped )
            {
                jadge.SetActive(true);
                snow.gameObject.SetActive(true);
                snow.Play();
                StartCoroutine(DelayMethod(particleStop, () => {snow.gameObject.SetActive(false);}));

                //Instantiate( 生成するオブジェクト,  場所, 回転 );  
                Instantiate(target, targetPosi, Quaternion.identity);
            }
        }

        private void UpdateSnowPosi()
        {
            snowPosi = new Vector3(assistFairy.transform.position.x, assistFairy.transform.position.y, assistFairy.transform.position.z);
        }

        private void UpdateTargetPosi()
        {
            targetPosi = new Vector3(assistFairy.transform.position.x + 1.0f, assistFairy.transform.position.y, assistFairy.transform.position.z);
        }

        IEnumerator DelayMethod(float waitTime, UnityAction action)
        {
            yield return new WaitForSeconds(waitTime);
            action();
        }
    }
}
