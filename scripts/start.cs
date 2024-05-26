using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class start: MonoBehaviour
{
    // ��ȯ�� ���� �̸��� �Է��մϴ�.
    public string sceneName;

    void Start()
    {
        // ���� GameObject�� Button ������Ʈ�� �ִ��� Ȯ���մϴ�.
        Button button = GetComponent<Button>();
        if (button != null)
        {
            // ��ư�� Ŭ���Ǹ� OnStartButtonClicked �Լ��� ȣ��ǵ��� �����մϴ�.
            button.onClick.AddListener(OnStartButtonClicked);
        }
        else
        {
            Debug.LogError("Button ������Ʈ�� �����ϴ�.");
        }
    }

    void OnStartButtonClicked()
    {
        // ������ ������ ��ȯ�մϴ�.
        SceneManager.LoadScene(sceneName);
    }
}
