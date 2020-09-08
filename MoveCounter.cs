using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace CS
{
    public class MoveCounter : MonoBehaviour
    {
        public TMPro.TMP_Text CurrentMovesText;
        public TMPro.TMP_Text RecordMovesText;
        public TMPro.TMP_Text TargetMovesText;
        public TMPro.TMP_Text FinalMovesText;
        public TMPro.TMP_Text PerfectText;
        public TMPro.TMP_Text CompletionPercentageText;
        public PerfectStar Star;
        public GameObject HintReminderArrow;
        int hintReminderMoveCount;
        bool hintReminderShown = false;
        int currentMoves;
        int totalMoves;
        Level currentLevel;

        private void Start()
        {
            resetCount();
            totalMoves = 0;
            currentLevel = LevelSelector.instance.current();
            hintReminderMoveCount = currentLevel.moveTarget * 3;
            if (currentLevel.moveRecord > 0)
            {
                RecordMovesText.text = Language.GetString(18) + currentLevel.moveRecord.ToString();
            }
            else
                RecordMovesText.text = Language.GetString(18) + "-";
            TargetMovesText.text = Language.GetString(19) + currentLevel.moveTarget.ToString();
            CompletionPercentageText.text = Language.CompletePercentString(LevelSelector.instance.PercentComplete());
        }
        private void OnEnable()
        {
            ResetLevel.Event_ResetLevel += resetCount;
        }
        private void OnDisable()
        {
            ResetLevel.Event_ResetLevel -= resetCount;
        }
        public void incrementMoveCount()
        {
            currentMoves++;
            totalMoves++;
            CurrentMovesText.text = Language.GetString(17) + currentMoves.ToString();
            if (!hintReminderShown && totalMoves >= hintReminderMoveCount)
            {
                setReminderShown();
                HintReminderArrow.SetActive(true);
            }
        }
        public void resetCount()
        {
            currentMoves = 0;
            CurrentMovesText.text = Language.GetString(17) + "0";
        }
        public void moveRecord()
        {
            string finalMoves = currentMoves.ToString();
            FinalMovesText.text = Language.GetString(17) + finalMoves;
            if (currentMoves <= currentLevel.moveTarget)
            {
                PerfectText.text = Language.GetString(30);
                Star.showStar();
                LevelSelector.instance.perfectScore();
            }
            else
            {
                PerfectText.text = Language.TargetMoveCountString(currentLevel.moveTarget);
            }
            if (currentLevel.moveRecord < 0 || currentMoves < currentLevel.moveRecord)
            {
                currentLevel.moveRecord = currentMoves;
                RecordMovesText.text = Language.GetString(18) + currentMoves.ToString();
                SaveData.saveLevel(currentLevel);
                LevelSelector.instance.updateButton(finalMoves);
                CompletionPercentageText.text = Language.CompletePercentString(LevelSelector.instance.PercentComplete());
            }
        }
        public void showTarget()
        {
            TargetMovesText.gameObject.SetActive(true);
            TargetMovesText.text = Language.GetString(19) + currentLevel.moveTarget.ToString();
        }
        public void setReminderShown()
        {
            hintReminderShown = true;
            HintReminderArrow.SetActive(false);
        }
    }
}
