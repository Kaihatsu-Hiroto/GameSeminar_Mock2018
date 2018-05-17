using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GoalText : MonoBehaviour {

    [SerializeField]
    private Text m_text;

    private Camera m_camera;

    [SerializeField]
    private Player m_player;

    private void Start(){
        m_text.enabled = false;
    }
    // Update is called once per frame
    void Update () {
        if (m_player.isGoal)
            m_text.enabled = true;
        m_text.text = "STAGE CLEAR";
    }
}
