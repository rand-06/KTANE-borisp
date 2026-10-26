using System.Collections;
using UnityEngine;
using Rnd = UnityEngine.Random;

public class borisScript : MonoBehaviour
{
    public KMAudio Audio;
    public AudioClip solved;
    public AudioClip correct;
    //public Font[] fonts;
    //public Material fontMat;
    //public Texture[] fontMaterials;
    public TextMesh[] allFonts;
    public GameObject[] allFontsObjects;
    public TextMesh topScreen;
    public Texture[] faces;
    public MeshRenderer screen;


    static int ModuleIdCounter = 1;
    int ModuleId;
    private bool ModuleSolved;

    private string[] selWords = new string[4];
    private int[] fontId = new int[4];
    private int[] faceId = new int[4];

    private string alphabet = "abcdefghijklmnopqrstuvwxyz";
    private string ALPHABET = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
    private int stage;
    private string solution;
    private bool _moduleSelected;

    private string[] words = {
        "ABLE", "ACHE", "ACID", "ACNE", "ACRE", "AGED", "AIDE", "AKIN", "ALAS", "ALLY", "ALSO", "AMEN", "AMID", "APEX", "AQUA", "ARCH", "AREA", "ARID", "ARMY", "ATOM", "AUNT", "AURA", "AWAY", "AXES", "AXIS", "AXLE",
            "BABY", "BACK", "BAIL", "BAIT", "BAKE", "BALD", "BALL", "BAND", "BANG", "BANK", "BARE", "BARK", "BARN", "BASE", "BASS", "BATH", "BATS", "BEAD", "BEAM", "BEAN", "BEAR", "BEAT", "BEEF", "BEEN", "BEER", "BELL", "BELT", "BEND", "BENT", "BEST", "BIAS", "BIKE", "BILE", "BILL", "BIND", "BIRD", "BITE", "BLAH", "BLEW", "BLOW", "BLUE", "BLUR", "BOAR", "BOAT", "BODY", "BOIL", "BOLD", "BOLT", "BOMB", "BOND", "BONE", "BONY", "BOOK", "BOOM", "BOOT", "BORE", "BORN", "BOSS", "BOTH", "BOUT", "BOWL", "BROW", "BULB", "BULK", "BULL", "BUMP", "BURN", "BURY", "BUSH", "BUST", "BUSY", "BUTT", "BUZZ",
            "CAFE", "CAGE", "CAKE", "CALF", "CALL", "CALM", "CAME", "CAMP", "CANE", "CAPE", "CARD", "CARE", "CARP", "CART", "CASE", "CASH", "CAST", "CAVE", "CELL", "CHAP", "CHAT", "CHEF", "CHIN", "CHIP", "CHOP", "CITY", "CLAD", "CLAM", "CLAN", "CLAP", "CLAW", "CLAY", "CLIP", "CLOG", "CLUB", "CLUE", "COAL", "COAT", "COCK", "CODE", "COIL", "COIN", "COLD", "COMB", "COME", "CONE", "COOK", "COOL", "COPE", "COPY", "CORD", "CORE", "CORK", "CORN", "COST", "COSY", "COUP", "COZY", "CRAB", "CREW", "CRIB", "CROP", "CROW", "CUBE", "CULT", "CURB", "CURE", "CURL", "CUTE",
            "DAFT", "DAMP", "DARE", "DARK", "DART", "DASH", "DATA", "DATE", "DAWN", "DAYS", "DEAD", "DEAF", "DEAL", "DEAR", "DEBT", "DECK", "DEED", "DEEP", "DEER", "DENT", "DENY", "DESK", "DIAL", "DICE", "DIET", "DINE", "DIRE", "DIRT", "DISC", "DISH", "DISK", "DIVE", "DOCK", "DOLE", "DOLL", "DOME", "DONE", "DOOR", "DOSE", "DOVE", "DOWN", "DRAG", "DRAW", "DREW", "DRIP", "DROP", "DRUG", "DRUM", "DUAL", "DUCK", "DUEL", "DUET", "DULL", "DULY", "DUMB", "DUMP", "DUSK", "DUST", "DUTY",
            "EACH", "EARN", "EARS", "EASE", "EAST", "EASY", "EATS", "ECHO", "EDGE", "EDIT", "ELSE", "ENVY", "EPIC", "EURO", "EVEN", "EVER", "EVIL", "EXAM", "EXIT", "EYED", "EYES",
            "FACE", "FACT", "FADE", "FAIL", "FAIR", "FAKE", "FALL", "FAME", "FARE", "FARM", "FAST", "FATE", "FEAR", "FEAT", "FEED", "FEEL", "FEET", "FELL", "FELT", "FILE", "FILL", "FILM", "FIND", "FINE", "FIRE", "FIRM", "FISH", "FIST", "FIVE", "FLAG", "FLAP", "FLAT", "FLAW", "FLED", "FLEE", "FLEW", "FLEX", "FLIP", "FLOW", "FLUX", "FOAM", "FOIL", "FOLD", "FOLK", "FOND", "FONT", "FOOD", "FOOL", "FOOT", "FORD", "FORK", "FORM", "FORT", "FOUL", "FOUR", "FREE", "FROG", "FROM", "FUEL", "FULL", "FUND", "FURY", "FUSE", "FUSS",
            "GAIN", "GALA", "GALL", "GAME", "GANG", "GASP", "GATE", "GAVE", "GAZE", "GEAR", "GENE", "GERM", "GIFT", "GILL", "GILT", "GIRL", "GIVE", "GLAD", "GLEE", "GLOW", "GLUE", "GOAL", "GOAT", "GOES", "GOLD", "GOLF", "GONE", "GONG", "GOOD", "GOSH", "GOWN", "GRAB", "GRAM", "GRAY", "GREW", "GREY", "GRID", "GRIM", "GRIN", "GRIP", "GRIT", "GROW", "GUST",
            "HAIL", "HAIR", "HALF", "HALL", "HALT", "HAND", "HANG", "HARD", "HARE", "HARM", "HATE", "HAUL", "HAVE", "HAWK", "HAZE", "HEAD", "HEAL", "HEAP", "HEAR", "HEAT", "HEEL", "HEIR", "HELD", "HELL", "HELP", "HERB", "HERD", "HERE", "HERO", "HERS", "HIDE", "HIGH", "HIKE", "HILL", "HINT", "HIRE", "HOLD", "HOLE", "HOLY", "HOME", "HOOD", "HOOK", "HOPE", "HORN", "HOSE", "HOST", "HOUR", "HOWL", "HUGE", "HULL", "HUNG", "HUNT", "HURT", "HUSH", "HYMN", "HYPE",
            "ICED", "ICON", "IDEA", "IDLE", "IDOL", "INCH", "INFO", "INTO", "IRON", "ITCH", "ITEM",
            "JACK", "JAIL", "JARS", "JAZZ", "JINX", "JOBS", "JOIN", "JOKE", "JUMP", "JUNK", "JURY", "JUST",
            "KEEN", "KEEP", "KELP", "KEPT", "KICK", "KILL", "KIND", "KING", "KISS", "KITE", "KIWI", "KNEE", "KNEW", "KNIT", "KNOB", "KNOT", "KNOW",
            "LACE", "LACK", "LADY", "LAID", "LAIR", "LAKE", "LAMB", "LAMP", "LAND", "LANE", "LAST", "LATE", "LAVA", "LAWN", "LAZY", "LEAD", "LEAF", "LEAK", "LEAN", "LEAP", "LEFT", "LEND", "LENS", "LESS", "LEST", "LEVY", "LIAR", "LIED", "LIFE", "LIFT", "LIKE", "LIMB", "LIME", "LINE", "LINK", "LION", "LIST", "LIVE", "LOAD", "LOAF", "LOAN", "LOCK", "LOFT", "LOGO", "LONE", "LONG", "LOOK", "LOOP", "LORD", "LOSE", "LOSS", "LOST", "LOTS", "LOUD", "LOVE", "LUCK", "LUMP", "LUNG", "LURE", "LUSH", "LUST",
            "MADE", "MAID", "MAIL", "MAIN", "MAKE", "MALE", "MALL", "MALT", "MANY", "MARE", "MARK", "MASK", "MASS", "MAST", "MATE", "MATH", "MAZE", "MEAL", "MEAN", "MEAT", "MEET", "MELT", "MEMO", "MENU", "MERE", "MESH", "MESS", "MICE", "MILD", "MILE", "MILK", "MILL", "MIME", "MIND", "MINE", "MINI", "MINT", "MISS", "MIST", "MOAT", "MOCK", "MODE", "MOLD", "MOLE", "MONK", "MOOD", "MOON", "MOOR", "MORE", "MOSS", "MOST", "MOTH", "MOVE", "MUCH", "MULE", "MUST", "MUTE", "MYTH",
            "NAIL", "NAME", "NAVE", "NEAR", "NEAT", "NECK", "NEED", "NEON", "NEST", "NEWS", "NEWT", "NEXT", "NICE", "NICK", "NINE", "NODE", "NONE", "NOOK", "NOON", "NORM", "NOSE", "NOTE", "NOUN", "NUMB", "NUTS",
            "OATH", "OATS", "OBEY", "OBOE", "ODDS", "ODOR", "OGRE", "OILY", "OINK", "OKAY", "OMEN", "OMIT", "ONCE", "ONLY", "ONTO", "OOZE", "OPEN", "ORAL", "ORCA", "ORES", "OURS", "OVAL", "OVEN", "OVER",
            "PACE", "PACK", "PACT", "PAGE", "PAID", "PAIN", "PAIR", "PALE", "PALM", "PARK", "PART", "PASS", "PAST", "PATH", "PAWN", "PEAK", "PEAR", "PEAT", "PEEK", "PEEL", "PEER", "PERK", "PEST", "PICK", "PIER", "PILE", "PILL", "PINE", "PINK", "PINT", "PIPE", "PITY", "PLAN", "PLAY", "PLEA", "PLOT", "PLOW", "PLOY", "PLUG", "PLUM", "PLUS", "POEM", "POET", "POKE", "POLE", "POLL", "POLO", "POND", "PONY", "POOL", "POOR", "PORK", "PORT", "POSE", "POSH", "POST", "POUR", "PRAY", "PREY", "PROP", "PULL", "PUMP", "PUNK", "PURE", "PUSH",
            "QUAY", "QUID", "QUIT", "QUIZ",
            "RACE", "RACK", "RAFT", "RAGE", "RAID", "RAIL", "RAIN", "RAKE", "RAMP", "RANK", "RARE", "RASH", "RATE", "READ", "REAL", "REAR", "REEF", "RELY", "RENT", "REST", "RICE", "RICH", "RIDE", "RIFT", "RING", "RIOT", "RIPE", "RISE", "RISK", "RITE", "ROAD", "ROAM", "ROAR", "ROBE", "ROCK", "RODE", "ROLE", "ROLL", "ROOF", "ROOM", "ROOT", "ROPE", "ROSE", "ROSY", "RUBY", "RUDE", "RUIN", "RULE", "RUNG", "RUSH", "RUST",
            "SACK", "SAFE", "SAGA", "SAID", "SAIL", "SAKE", "SALE", "SALT", "SAME", "SAND", "SANE", "SANG", "SANK", "SAVE", "SCAN", "SCAR", "SCUM", "SEAL", "SEAM", "SEAT", "SEED", "SEEK", "SEEM", "SEEN", "SELF", "SELL", "SEND", "SENT", "SEXY", "SHED", "SHIP", "SHOE", "SHOP", "SHOT", "SHOW", "SHUT", "SICK", "SIDE", "SIGH", "SIGN", "SILK", "SING", "SINK", "SITE", "SIZE", "SKIN", "SKIP", "SLAB", "SLAM", "SLID", "SLIM", "SLIP", "SLOT", "SLOW", "SLUM", "SMUG", "SNAP", "SNOW", "SOAP", "SOAR", "SODA", "SOFA", "SOFT", "SOIL", "SOLD", "SOLE", "SOLO", "SOME", "SONG", "SOON", "SORE", "SORT", "SOUL", "SOUP", "SOUR", "SPAN", "SPIN", "SPOT", "SPUN", "SPUR", "STAB", "STAR", "STAY", "STEM", "STEP", "STIR", "STOP", "SUCH", "SUIT", "SUNG", "SUNK", "SURE", "SWAN", "SWAP", "SWIM",
            "TACK", "TACO", "TAIL", "TAKE", "TALE", "TALK", "TALL", "TAME", "TANK", "TAPE", "TASK", "TAUT", "TAXI", "TEAL", "TEAM", "TEAR", "TELL", "TEND", "TENT", "TERM", "TEST", "TEXT", "THAN", "THAT", "THAW", "THEE", "THEM", "THEN", "THEY", "THIN", "THIS", "THOU", "THUD", "THUS", "TIDE", "TIDY", "TIED", "TIER", "TILE", "TILL", "TILT", "TIME", "TINY", "TIRE", "TOAD", "TOIL", "TOLD", "TOLL", "TOMB", "TONE", "TOOK", "TOOL", "TORE", "TORN", "TORT", "TORY", "TOSS", "TOUR", "TOWN", "TRAM", "TRAP", "TRAY", "TREE", "TRIM", "TRIO", "TRIP", "TRUE", "TSAR", "TUBE", "TUCK", "TUNA", "TUNE", "TURF", "TURN", "TWIN", "TYPE",
            "UGLY", "UNDO", "UNIT", "UNTO", "UPON", "URGE", "USED", "USER", "USES",
            "VAIN", "VARY", "VASE", "VAST", "VEIL", "VEIN", "VENT", "VERB", "VERY", "VEST", "VETO", "VIAL", "VIEW", "VILE", "VINE", "VISA", "VOID", "VOTE",
            "WADE", "WAGE", "WAIT", "WAKE", "WALK", "WALL", "WAND", "WANT", "WARD", "WARM", "WARN", "WARP", "WARY", "WASH", "WAVE", "WAVY", "WAXY", "WEAK", "WEAR", "WEED", "WEEK", "WELD", "WELL", "WENT", "WERE", "WEST", "WHAT", "WHEN", "WHIP", "WHOM", "WIDE", "WIFE", "WILD", "WILL", "WIND", "WINE", "WING", "WIPE", "WIRE", "WISE", "WISH", "WITH", "WOLF", "WOMB", "WOOD", "WOOL", "WORD", "WORE", "WORK", "WORM", "WORN", "WRAP", "WRIT",
            "XYLO",
            "YARD", "YARN", "YAWN", "YEAH", "YEAR", "YELL", "YOGA", "YOUR",
            "ZEAL", "ZERO", "ZINC", "ZONE", "ZOOM"
    };
    void Awake()
    {
        ModuleId = ModuleIdCounter++;
    }

    int mod(int a, int b)
    {
        while (a < 0) a += b;
        return a % b;
    }

    int sqrt(int num)
    {
        int ans = 1;
        while (ans * ans <= num) ans++;
        return ans - 1;
    }

    char rule(char original, int font, int face, int s, int p)
    {
        int n = original - 'A';
        int ans;
        switch (face * 4 + font)
        {
            case  0: ans = 2 * n;               break;
            case  1: ans = n + s*p;             break;
            case  2: ans = n * (n + 1);         break;
            case  3: ans = n + n / p;           break;
            case  4: ans = n + sqrt(n * s);     break;
            case  5: ans = 3 * n;               break;
            case  6: ans = n + s;               break;
            case  7: ans = (int)(3.14f * n);    break;
            case  8: ans = p * n;               break;
            case  9: ans = n / p;               break;
            case 10: ans = 4 * n;               break;
            case 11: ans = n;                   break;
            case 12: ans = s * p * n;           break;
            case 13: ans = n - s * p;           break;
            case 14: ans = s * n;               break;
            case 15: ans = 5 * n;               break;
            default: ans = 0; break;
        }
        return (char)(mod(ans, 26) + 'A');
    }

    void generateWords()
    {
        for (int i = 0; i < 4; i++)
        {
            selWords[i] = words[Rnd.Range(0, words.Length)];
            fontId[i] = Rnd.Range(0, 4);
            faceId[i] = Rnd.Range(0, 4);
        }

        Debug.LogFormat("[BorisP #{0}] Your original words for 4 stages will be: {1}",ModuleId,selWords[0] + " " + selWords[1] + " " + selWords[2] + " " + selWords[3]);

    }

    void answer()
    {
        string[] stages = new string[4];
        string ans = "";
        for (int i = 0; i < 4; i++)
        {
            for (int j = 0; j < 4; j++)
            {
                stages[i] += rule(selWords[i][j], fontId[i], faceId[i],i+1,j+1);
            }
        }
        Debug.LogFormat("[BorisP #{0}] Your modified words for 4 stages will be: {1}",ModuleId,
            stages[0] + " " + stages[1] + " " + stages[2] + " " + stages[3]);

        for (int i = 0; i < 4; i++)
        {
            int letter = 0;
            for (int j = 0; j <= i; j++)
            {
                letter += stages[j][i] - 'A';
            }
            //Debug.Log(letter+" "+ (char)((letter % 26) + 'A'));
            ans += (char)((letter % 26) + 'A');
        }

        solution = ans;
        Debug.LogFormat("[BorisP #{0}] Ans: {1}", ModuleId, solution);
    }

    void Start()
    {
        GetComponent<KMSelectable>().OnFocus += delegate { _moduleSelected = true; };
        GetComponent<KMSelectable>().OnDefocus += delegate { _moduleSelected = false; };
        generateWords();
        answer();
        topScreen.text = "";
        //bottomScreen.font = fonts[fontId[0]];
        //fontMat.mainTexture = fontMaterials[fontId[0]];
        //bottomScreen.text = selWords[0];
        setFont(fontId[0],selWords[0]);
        screen.material.mainTexture = faces[faceId[0]];
    }

    void solve()
    {
        topScreen.text = "SOLVED";
        setFont(0, "");
        //bottomScreen.text = "";
        GetComponent<KMBombModule>().HandlePass();
        screen.material.mainTexture = faces[4];
        Audio.HandlePlaySoundAtTransform(solved.name, transform);
    }

    void setFont(int id, string word)
    {
        allFontsObjects[id].SetActive(true);
        for (int i = 1; i < 4; i++)
        {
            allFontsObjects[(id+i)%4].SetActive(false);
        }

        allFonts[id].text = word;
    }
    
    void keypress(char c) {
        if (c == solution[stage])
        {
            stage++;
            if (stage == 4) { solve(); return; }
            topScreen.text = solution.Substring(0, stage);
                //bottomScreen.font = fonts[fontId[stage]];
                //fontMat.mainTexture = fontMaterials[fontId[stage]];
            setFont(fontId[stage],selWords[stage]);
            
            screen.material.mainTexture = faces[faceId[stage]];

            Audio.HandlePlaySoundAtTransform(correct.name, transform);
        }
        else
        {
            GetComponent<KMBombModule>().HandleStrike();
        }
    }


    void Update() { if (_moduleSelected) for (var ltr = 0; ltr < 26; ltr++) if (Input.GetKeyDown(alphabet[ltr].ToString())) keypress(ALPHABET[ltr]); }

#pragma warning disable 414
    private readonly string TwitchHelpMessage = @"Use !{0} <letter> to input letter.";
#pragma warning restore 414

    IEnumerator ProcessTwitchCommand(string Command)
    {
		var commandArgs = Command.ToUpperInvariant();
        yield return null;
        if (commandArgs.Length == 1 && commandArgs[0] >= 'A' && commandArgs[0] <= 'Z')
        {
            keypress(commandArgs[0]);
        }
        else yield return "sendtochaterror Сommand is not valid.";
    }

    IEnumerator TwitchHandleForcedSolve()
    {
        yield return null;
        solve();
    }

}
