package kr.ac.korea.ee.shygiants.gameunivlogin;

import com.loopj.android.http.AsyncHttpClient;
import com.loopj.android.http.AsyncHttpResponseHandler;
import com.loopj.android.http.RequestParams;

/**
 * Created by SHYBook_Air on 15. 11. 18..
 */
public class GameUnivAccessTokens {

    private final static String apiEndPoint = "10.64.19.40";
    private final static String port = "3000";
    private final static String accessTokenRoute = "/accessTokens";

    public static void getAccessToken(String authCode, String gameId, String gameSecret, AsyncHttpResponseHandler responseHandler) {
        AsyncHttpClient client = new AsyncHttpClient();

        RequestParams requestBody = new RequestParams();
        requestBody.put("grant_type", "authorization_code");
        requestBody.put("code", authCode);
        requestBody.put("client_id", gameId);
        client.addHeader("Authorization", gameSecret);

        client.post("http://" + apiEndPoint + ":" + port + accessTokenRoute, requestBody, responseHandler);
    }
}
