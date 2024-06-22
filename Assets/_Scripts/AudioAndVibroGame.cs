using UnityEngine;

public class AudioAndVibroGame : MonoBehaviour
{
    [SerializeField] private AudioClip clickAudioClip;
    [SerializeField] private AudioClip bonusAudioClip;
    [SerializeField] private AudioClip coinAudioClip;
    [SerializeField] private AudioClip loseAudioClip;
    [SerializeField] private AudioClip winAudioClip;
    [SerializeField] private AudioClip Percent100AudioClip;
    [SerializeField] private AudioClip enemyAudioClip;
    private AudioSource audioPlayer;
    public static bool isVibrationEnabled;

    private void Start()
    {
        Vibration.Init();
        int vibrationSetting = PlayerPrefs.GetInt("vibrationSetting", 1);
        isVibrationEnabled = vibrationSetting == 1;
        audioPlayer = GetComponent<AudioSource>();
    }

    public void PlayClickAudio()
    {
        audioPlayer.PlayOneShot(clickAudioClip);
        if (isVibrationEnabled) Vibration.VibrateIOS(ImpactFeedbackStyle.Light);
    }

    public void PlayBonusAudio()
    {
        audioPlayer.PlayOneShot(bonusAudioClip);
        if (isVibrationEnabled) Vibration.VibrateIOS(ImpactFeedbackStyle.Rigid);
    }

    public void PlayCoinAudio()
    {
        audioPlayer.PlayOneShot(coinAudioClip);
        if (isVibrationEnabled) Vibration.VibrateIOS(ImpactFeedbackStyle.Heavy);
    }

    public void PlayLoseSound()
    {
        audioPlayer.Stop();
        audioPlayer.PlayOneShot(loseAudioClip);
        if (isVibrationEnabled) Vibration.VibrateIOS(NotificationFeedbackStyle.Error);
    }

    public void PlayWinSound()
    {
        audioPlayer.Stop();
        audioPlayer.PlayOneShot(winAudioClip);
        if (isVibrationEnabled) Vibration.VibrateIOS(NotificationFeedbackStyle.Success);
    }

    public void PlayPercent100AudioClip()
    {
        audioPlayer.PlayOneShot(Percent100AudioClip);
        if (isVibrationEnabled) Vibration.VibrateIOS(NotificationFeedbackStyle.Warning);
    }

    public void PlayEnemyAudioClip()
    {
        audioPlayer.PlayOneShot(enemyAudioClip);
        if (isVibrationEnabled) Vibration.VibrateIOS(ImpactFeedbackStyle.Medium);
    }
}