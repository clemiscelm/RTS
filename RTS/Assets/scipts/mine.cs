using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class mine : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] float m_range = 5f;
    [SerializeField] float m_timeToWait = 5f;
    [SerializeField] int m_mult = 5;
    [SerializeField] int m_currentEntity = 0;
    [SerializeField] int m_golds = 0;
    [SerializeField] bool needWait = false;
    [SerializeField] Text golds;

    // Update is called once per frame
    void Update()
    {
        isInrange();
        getMoney();
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, m_range);
    }

    public void isInrange()
    {

        GameObject[] entities = GameObject.FindGameObjectsWithTag("units");
        int temp = 0;
        foreach(GameObject entity in entities)
        {
            float dist = Vector3.Distance(this.transform.position, entity.transform.position);

            if (dist <= m_range)
            {
                temp++;
            }
        }
        m_currentEntity = temp;

    }


    public IEnumerator waiting()
    {
            yield return new WaitForSeconds(m_timeToWait);
            needWait = false;
        
    }
    public void getMoney()
    {
        if(!needWait)
        {
            m_golds += m_mult * m_currentEntity;
            golds.text = m_golds.ToString();
            needWait = true;
            StartCoroutine(waiting());
        }
        
    }
    
}
