
namespace CS
{
    public enum LanguageCode { ENG, SPA, FR, DE, ITA, POR, RUS, CHI, JAP};

    public static class Language
    {
        public static LanguageCode CurrentLanguage;

        public static const string[] ENGLISH =
        {
            "Start",
            "Continue",
            "Level Select",
            "Settings",
            "Disable Ads",
            "Sensitivity",
            "Transitions",
            "Replay Tutorial",
            "Reset Data",
            "Restore Purchases",
            "Store Page",
            "Complete: ",
            "Perfect: ",
            "Swipe to move",
            "Slide to the Goal",
            "Move all sliders into goals to complete the level",
            "LEVEL COMPLETE",
            "Moves: ",
            "Best: ",
            "Target: ",
            "Target number of moves is ",
            "You've completed ",
            "Level ",
            "WARNING",
            "This will Clear all Level Data. Continue?",
            "Slider colors have to match goal colors",
            "Arrow Tiles move sliders by one space",
            "Language",
            "Next Level",
            "Main Menu",
            "PERFECT",
            "Hint",
            "Playing ad",
            "Review Synchro Slide?",
            "Yes",
            "Later",
            "No"
        };
        public static const string[] FRENCH =
        {
            "Commencer",
            "Continuer",
            "Sélection du niveau",
            "Paramètres",
            "Désactiver les annonces",
            "Sensibilité",
            "Transitions",
            "Revoir le tutoriel",
            "Réinitialiser les données",
            "Restaurer les achats",
            "Page du magasin",
            "Compléter: ",
            "Parfait: ",
            "Glisser pour déplacer",
            "Faites glisser vers l'objectif",
            "Déplacez tous les glisseurs dans les objectifs pour terminer le niveau",
            "NIVEAU TERMINÉ",
            "Mouvement: ",
            "Meilleur: ",
            "Cible : ",
            "Le nombre de coups ciblé est de ",
            "Vous avez terminé ",
            "Niveau ",
            "AVERTISSEMENT",
            "Ceci effacera toutes les données de niveau. Continuer?",
            "Les couleurs des glisseurs doivent correspondre aux couleurs du but",
            "Les carreaux de flèche déplacent les glisseurs d'un espace",
            "La langue",
            "Niveau suivant",
            "Menu principal",
            "PARFAIT",
            "Allusion",
            "Lecture d'une annonce",
            "Revoir Synchro Slide?",
            "Oui",
            "Plus tard",
            "Non"
        };

        public static const string[] GERMAN =
        {
            "Starten",
            "Weiter",
            "Ebene auswählen",
            "Einstellungen",
            "Werbung Deaktivieren",
            "Empfindlichkeit",
            "Übergänge",
            "Das Tutorial wiederholen",
            "Daten zurücksetzen",
            "Käufe wiederherstellen",
            "Seite speichern",
            "Fertig: ",
            "Perfekt: ",
            "Wischen Sie zum Verschieben",
            "Schieben Sie zum Ziel",
            "Bewegen Sie alle Schieberegler in Ihre Ziele, um das Level zu beenden",
            "EBENE BEENDEN",
            "Bewegungen: ",
            "Beste: ",
            "Ziel: ",
            "Zielanzahl der Züge ist ",
            "Sie haben 00.00% abgeschlossen",
            "Stufe ",
            "WARNUNG",
            "Dadurch werden alle Level-Daten gelöscht. Fortsetzen?",
            "Slider -Farben müssen den Zielfarben entsprechen",
            "Arrow Tiles bewegt Schieberegler um ein einziges Feld",
            "Sprache",
            "Nächste Ebene",
            "Hauptmenü",
            "PERFEKT",
            "Hinweis",
            "Anzeige wird wiedergegeben",
            "Kritik Synchro Slide?",
            "Ja",
            "Später",
            "Nein"
        };

        public static const string[] ITALIAN =
        {
            "Inizia",
            "Continua",
            "Seleziona Livello",
            "Impostazioni",
            "Disattiva Notifiche",
            "Sensibilità Scorrimento",
            "Attiva Animazioni",
            "Rigioca Tutorial",
            "Reset Dati",
            "Ripristino Acquisti",
            "Pagina dello Store",
            "Completamento Gioco: ",
            "Percentuale Perfect: ",
            "Scorri per muovere",
            "Vai all'Obiettivo",
            "Muovi tutti i cursori sugli obiettivi per completare il livello",
            "LIVELLO COMPLETATO",
            "Mosse: ",
            "Record: ",
            "Numero Mosse: ",
            "Il Numero Mosse è ",
            "Hai completato ",
            "Livello ",
            "ATTENZIONE",
            "Quest'azione cancellerà tutti i Dati dei Livelli. Continuare?",
            "I colori dei cursori devono corrispondere a quelli degli obiettivi.",
            "Le Frecce muovono i cursori di uno spazio",
            "linguaggio",
            "Livello successivo",
            "Menu principale",
            "PERFETTO",
            "Suggerimento",
            "Riproduzione dell'annuncio",
            "Rivedi Synchro Slide?",
            "sì",
            "Dopo",
            "No"
        };

        public static const string[] PORTUGUESE =
        {
            "Começar",
            "Continuar",
            "Escolher Nível",
            "Configurações",
            "Remover Anúncio",
            "Sensibilidade",
            "Transições",
            "Repetir o Tutorial",
            "Redefinir Dados",
            "Restaurar Compras",
            "[Página na] Play Store",
            "Completo: ",
            "Perfeito: ",
            "Deslize para mover",
            "Deslize até ao Objetivo",
            "Mova todos os sliders até aos objetivos para completar o nível",
            "NÍVEL COMPLETO",
            "Jogadas: ",
            "Melhor Marca: ",
            "Objetivo: ",
            "O objetivo é resolver em ",
            "Você completou ",
            "Nível ",
            "ATENÇÃO",
            "Isto vai eliminar todos os dados de nível guardados. Quer continuar?",
            "As cores dos sliders têm de conferir com as cores dos objetivos",
            "As casas com uma seta movem os sliders um espaço",
            "Língua",
            "Próximo nível",
            "Menu principal",
            "Perfeito",
            "Sugestão",
            "Jogando anúncio",
            "Avaliação Synchro Slide?",
            "sim",
            "Mais tarde",
            "não"
        };

        public static const string[] RUSSIAN =
        {
            "Играть",
            "Продолжить",
            "Выбор уровня",
            "Настройки",
            "Отключить рекламы",
            "Чувствительность",
            "Переходы",
            "Повторное воспроизведение туториала",
            "Сбросить данные",
            "Восстановить покупки",
            "Страница магазина",
            "Завершать: ",
            "Отлично: ",
            "Проведите пальцем на экран чтобы двигаться",
            "Проведите пальцем на экран чтобы достичь цель",
            "Переместите все ползунки в цель, чтобы завершить уровень",
            "УРОВЕНЬ ПРОЙДЕН",
            "Шаги: ",
            "Лучший результат: ",
            "Цель: ",
            "Целевое число ходов - ",
            "Вы завершили ",
            "Уровень ",
            "ПРЕДУПРЕЖДЕНИЕ",
            "Это удалить все данные уровня. Продолжать?",
            "Цвет ползунка должен соответствовать цветам целей",
            "Стрелочные поля перемещают ползунки на одно место",
            "язык",
            "Следующий уровень",
            "Главное меню",
            "ОТЛИЧНО",
            "намек",
            "Воспроизведение рекламы",
            "Обзор Synchro Slide?",
            "да",
            "Позже",
            "нет"
        };

        public static const string[] SPANISH =
        {
            "Inicio",
            "Continuar",
            "Seleccionar el Nivel",
            "Configuración",
            "Desactivar los Anuncios",
            "Sensibilidad",
            "Transiciones",
            "Reproducir el Tutorial",
            "Restablecer los Datos",
            "Restaurar Compras",
            "Página de la Tienda",
            "Completo: ",
            "Perfecto: ",
            "Desliza para Mover",
            "Desliza hacia el Objetivo",
            "Mueve todos los deslizadores hacia el objetivo para completar el nivel",
            "NIVEL COMPLETO",
            "Movimientos: ",
            "El mejor: ",
            "Objetivo: ",
            "El número de movimientos objetivos es ",
            "Has completado el ",
            "Nivel ",
            "ADVERTENCIA",
            "Esto Borrará todos los Datos. ¿Deseas Continuar?",
            "El color de los deslizadores debe coincidir con el color del objetivo",
            "Las Flechas mueven los deslizadores un espacio",
            "Idioma",
            "siguiente nivel",
            "Menú principal",
            "PERFECTO",
            "Insinuación",
            "Reproducción de anuncios",
            "¿Desea revisar Synchro Slide?",
            "Sí",
            "Luego",
            "No"
        };

        public static const string[] JAPANESE =
        {
            "始め",
            "続ける",
            "レベル選択",
            "設定",
            "広告を無効にする",
            "感圧",
            "トランジション",
            "リプレイチュートリアル",
            "データをリセットする",
            "購入を復元",
            "店舗ページ",
            "コンプリート: ",
            "パーフェクト: ",
            "スワイプからムーブへ",
            "目標へスライド",
            "すべてのスライダを目標に移動してレベルを完成させる",
            "レベル完了",
            "移動： ",
            "ベスト： ",
            "ターゲット： ",
            "目標移動数は",
            "を完了しました",
            "レベル",
            "警告",
            "これにより、すべてのレベルデータがクリアされます。 持続する？",
            "スライダの色は目標色に一致する必要があります",
            "矢印タイルはスライダを1スペース移動します",
            "言語",
            "次のレベル",
            "メインメニュー",
            "パーフェクト",
            "ヒント",
            "広告を再生する",
            "レビューシンクロスライド？",
             "はい",
             "「後で」",
             "いいえ"
        };

        public static const string[] CHINESE =
        {
            "开始",
            "继续",
            "选择关",
            "设置",
            "停用广告",
            "灵敏度",
            "转换",
            "重播教程",
            "重置数据",
            "恢复购买",
            "存储页面",
            "完成: ",
            "完美: ",
            "滑动移动",
            "滑向目标",
            "将所有滑块移至目标过关",
            "过关",
            "步: ",
            "最好： ",
            "目标： ",
            "目标移动次数为",
            "你已经完成了",
            "关",
            "警告",
            "这将清除所有关的数据。 继续？",
            "滑块颜色必须与目标颜色相匹配",
            "将滑块移动一个空格",
            "语言",
            "下一级",
            "主菜单",
            "完美",
            "暗示",
            "播放广告",
            "回顾Synchro Slide？",
             "是",
             "后来",
             "没有"
        };

        public static string GetString(int s)
        {
            switch (Language.CurrentLanguage)
            {
                case LanguageCode.ENG:
                    return Language.ENGLISH[s];
                case LanguageCode.DE:
                    return Language.GERMAN[s];
                case LanguageCode.FR:
                    return Language.FRENCH[s];
                case LanguageCode.ITA:
                    return Language.ITALIAN[s];
                case LanguageCode.POR:
                    return Language.PORTUGUESE[s];
                case LanguageCode.RUS:
                    return Language.RUSSIAN[s];
                case LanguageCode.SPA:
                    return Language.SPANISH[s];
                case LanguageCode.CHI:
                    return Language.CHINESE[s];
                case LanguageCode.JAP:
                    return Language.JAPANESE[s];
                default:
                    return Language.ENGLISH[s];
            }
        }

        public static string StartString()
        {
            switch (Language.CurrentLanguage)
            {
                case LanguageCode.ENG:
                    return "Start";
                case LanguageCode.DE:
                    return Language.GERMAN[0];
                case LanguageCode.FR:
                    return Language.FRENCH[0];
                case LanguageCode.ITA:
                    return Language.ITALIAN[0];
                case LanguageCode.POR:
                    return Language.PORTUGUESE[0];
                case LanguageCode.RUS:
                    return Language.RUSSIAN[0];
                case LanguageCode.SPA:
                    return Language.SPANISH[0];
                case LanguageCode.CHI:
                    return Language.CHINESE[0];
                case LanguageCode.JAP:
                    return Language.JAPANESE[0];
                default:
                    return "Start";
            }
        }

        public static string ContinueString()
        {
            switch (Language.CurrentLanguage)
            {
                case LanguageCode.ENG:
                    return "Continue";
                case LanguageCode.DE:
                    return Language.GERMAN[1];
                case LanguageCode.FR:
                    return Language.FRENCH[1];
                case LanguageCode.ITA:
                    return Language.ITALIAN[1];
                case LanguageCode.POR:
                    return Language.PORTUGUESE[1];
                case LanguageCode.RUS:
                    return Language.RUSSIAN[1];
                case LanguageCode.SPA:
                    return Language.SPANISH[1];
                case LanguageCode.CHI:
                    return Language.CHINESE[1];
                case LanguageCode.JAP:
                    return Language.JAPANESE[1];
                default:
                    return "Continue";
            }
        }

        public static string TargetMoveCountString(int moveCount)
        {
            switch (Language.CurrentLanguage)
            {
                case LanguageCode.ENG:
                    return Language.ENGLISH[20] + moveCount.ToString();
                case LanguageCode.DE:
                    return Language.GERMAN[20] + moveCount.ToString();
                case LanguageCode.FR:
                    return Language.FRENCH[20] + moveCount.ToString();
                case LanguageCode.ITA:
                    return Language.ITALIAN[20] + moveCount.ToString();
                case LanguageCode.POR:
                    return Language.PORTUGUESE[20] + moveCount.ToString() + " movimentos";
                case LanguageCode.RUS:
                    return Language.RUSSIAN[20] + moveCount.ToString();
                case LanguageCode.SPA:
                    return Language.SPANISH[20] + moveCount.ToString();
                case LanguageCode.CHI:
                    return Language.CHINESE[20] + moveCount.ToString();
                case LanguageCode.JAP:
                    return Language.JAPANESE[20] + moveCount.ToString();
                default:
                    return "Continue";
            }
        }
        
        public static string CompletePercentString(float percent)
        {
            switch (Language.CurrentLanguage)
            {
                case LanguageCode.ENG:
                    return Language.ENGLISH[21] + percent.ToString("0.00") + "%";
                case LanguageCode.DE:
                    return "Sie haben " + percent.ToString("0.00") + " abgeschlossen";
                case LanguageCode.FR:
                    return Language.FRENCH[21] + percent.ToString("0.00") + "%";
                case LanguageCode.ITA:
                    return Language.ITALIAN[21] + percent.ToString("0.00") + "%";
                case LanguageCode.POR:
                    return Language.PORTUGUESE[21] + percent.ToString("0.00") + "%";
                case LanguageCode.RUS:
                    return Language.RUSSIAN[21] + percent.ToString("0.00") + "%";
                case LanguageCode.SPA:
                    return Language.SPANISH[21] + percent.ToString("0.00") + "%";
                case LanguageCode.CHI:
                    return Language.CHINESE[21] + percent.ToString("0.00") + "%"; ;
                case LanguageCode.JAP:
                    return percent.ToString("0.00") + "%" + Language.JAPANESE[20];
                default:
                    return "Continue";
            }
        }

        public static string LevelNumberString(int l)
        {
            switch (Language.CurrentLanguage)
            {
                case LanguageCode.ENG:
                    return Language.ENGLISH[22] + l.ToString();
                case LanguageCode.DE:
                    return Language.GERMAN[22] + l.ToString();
                case LanguageCode.FR:
                    return Language.FRENCH[22] + l.ToString();
                case LanguageCode.ITA:
                    return Language.ITALIAN[22] + l.ToString();
                case LanguageCode.POR:
                    return Language.PORTUGUESE[22] + l.ToString();
                case LanguageCode.RUS:
                    return Language.RUSSIAN[22] + l.ToString();
                case LanguageCode.SPA:
                    return Language.SPANISH[22] + l.ToString();
                case LanguageCode.CHI:
                    return l.ToString() + Language.CHINESE[22];
                case LanguageCode.JAP:
                    return Language.JAPANESE[22] + l.ToString();
                default:
                    return Language.ENGLISH[22] + l.ToString();
            }
        }

    }
}