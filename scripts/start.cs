using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class start: MonoBehaviour
{
    // 전환할 씬의 이름을 입력합니다.
    public string sceneName;

    void Start()
    {
        // 현재 GameObject에 Button 컴포넌트가 있는지 확인합니다.
        Button button = GetComponent<Button>();
        if (button != null)
        {
            // 버튼이 클릭되면 OnStartButtonClicked 함수가 호출되도록 설정합니다.
            button.onClick.AddListener(OnStartButtonClicked);
        }
        else
        {
            Debug.LogError("Button 컴포넌트가 없습니다.");
        }
    }

    void OnStartButtonClicked()
    {
        // 지정된 씬으로 전환합니다.
        SceneManager.LoadScene(sceneName);
    }
}
