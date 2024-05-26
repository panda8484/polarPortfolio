using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PrologueDialogue : MonoBehaviour
{
    public UWPlayerMove UWPlayerMoveThis;
    public GameObject[] dialogueTexts; // text1���� text7������ GameObject �迭
    private GameObject currentActiveText = null;
    public string sceneName;

    private int currentDialogueIndex = 0; // ���� ��ȭ ������ �ε���
    private int dialogueSet = 0; // ���� ��ȭ ��Ʈ�� ��ȣ
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

        // �����̽��ٸ� ������ ���� Ȱ��ȭ�� �ؽ�Ʈ�� ��Ȱ��ȭ�ϰ� ���� ��ȭ�� ǥ��
        if (Input.GetKeyDown(KeyCode.Space) && currentActiveText != null)
        {
            currentActiveText.SetActive(false);
            currentActiveText = null;

            // ���� ��ȭ�� ������ ǥ���ϰ�, ������ ������ �簳
            ShowNextDialogue();
        }
    }

    private List<int> currentDialogueSet;

    private void ShowNextDialogue(int[] dialogueNumbers = null)
    {
        UWPlayerMoveThis.Stop();
        if (dialogueNumbers != null)
        {
            // ��ȭ ��Ʈ ����
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
                Debug.Log("��ȭ ���: " + number);
            }
        }
        else
        {
            // ��ȭ ��Ʈ�� ������ ������ �簳 �� ��Ʈ ��ȣ ����
            UWPlayerMoveThis.KeepGo();
            isDialogueActive = false;
            dialogueSet++;

            // ������ ��Ʈ�� ������ �� ��ȯ �ڷ�ƾ ����
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
