using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PrologueDialogue : MonoBehaviour
{
    public UWPlayerMove UWPlayerMoveThis;
    public GameObject[] dialogueTexts; // text1에서 text7까지의 GameObject 배열
    private GameObject currentActiveText = null;
    public string sceneName;

    private int currentDialogueIndex = 0; // 현재 대화 상자의 인덱스
    private int dialogueSet = 0; // 현재 대화 세트의 번호
    private bool isDialogueActive = false;

    // Update is called once per frame
    void Update()
    {
        Vector3 newPosition = UWPlayerMoveThis.transform.position;

        if (dialogueSet == 0 && -32 <= newPosition.x && newPosition.x <= -30)
        {
            
            if (!isDialogueActive)
            {
                ShowNextDialogue(new int[] { 1, 2, 3 });
            }
        }
        else if (dialogueSet == 1 && 64 <= newPosition.x && newPosition.x <= 67)
        {
            if (!isDialogueActive)
            {
                ShowNextDialogue(new int[] { 4 });
            }
        }
        else if (dialogueSet == 2 && 146 <= newPosition.x && newPosition.x <= 149)
        {
            if (!isDialogueActive)
            {
                ShowNextDialogue(new int[] { 5, 6, 7 });
            }
        }

        // 스페이스바를 누르면 현재 활성화된 텍스트를 비활성화하고 다음 대화를 표시
        if (Input.GetKeyDown(KeyCode.Space) && currentActiveText != null)
        {
            currentActiveText.SetActive(false);
            currentActiveText = null;

            // 다음 대화가 있으면 표시하고, 없으면 움직임 재개
            ShowNextDialogue();
        }
    }

    private List<int> currentDialogueSet;

    private void ShowNextDialogue(int[] dialogueNumbers = null)
    {
        UWPlayerMoveThis.Stop();
        if (dialogueNumbers != null)
        {
            // 대화 세트 시작
            currentDialogueSet = new List<int>(dialogueNumbers);
            currentDialogueIndex = 0;
            isDialogueActive = true;
        }

        if (currentDialogueIndex < currentDialogueSet.Count)
        {
            int number = currentDialogueSet[currentDialogueIndex];
            currentDialogueIndex++;

            if (number >= 1 && number <= dialogueTexts.Length)
            {
                currentActiveText = dialogueTexts[number - 1];
                currentActiveText.SetActive(true);
                Debug.Log("대화 출력: " + number);
            }
        }
        else
        {
            // 대화 세트가 끝나면 움직임 재개 및 세트 번호 증가
            UWPlayerMoveThis.KeepGo();
            isDialogueActive = false;
            dialogueSet++;

            // 마지막 세트가 끝나면 씬 전환 코루틴 시작
            if (dialogueSet == 3)
            {
                StartCoroutine(WaitAndLoadScene(3f));
            }
        }
    }

    private IEnumerator WaitAndLoadScene(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        SceneManager.LoadScene(sceneName);
    }
}
