package kr.ac.korea.ee.shygiants.gameunivlogin;

/**
 * Created by SHYBook_Air on 2015. 12. 25..
 */
public class AccessTokenRequest {

    private String grant_type;
    private String code;
    private String client_id;

    public AccessTokenRequest(String authCode, String clientId) {
        grant_type = "authorization_code";
        code = authCode;
        client_id = clientId;
    }
}
