package kr.ac.korea.ee.shygiants.gameunivlogin;

import android.content.Intent;
import android.net.Uri;

import com.unity3d.player.UnityPlayerActivity;

import retrofit.Callback;
import retrofit.Response;
import retrofit.Retrofit;

public class GameUnivUnityActivity extends UnityPlayerActivity {

    private static final int AUTH_CODE_REQUEST = 1;
    private static final String AUTH_CODE = "AUTH_CODE";

    private AccessTokenCallback callback;

    private String authCode;
    private String gameId;
    private String gameSecret;
    private String accessToken;

    @Override
    protected void onActivityResult(int requestCode, int resultCode, Intent data) {
        super.onActivityResult(requestCode, resultCode, data);

        if (requestCode != AUTH_CODE_REQUEST || resultCode != RESULT_OK) return;
        authCode = data.getStringExtra(AUTH_CODE);

        requestAccessToken();
    }

    public void attemptLogin(String gameId, String gameSecret, AccessTokenCallback callback) {
        this.gameId = gameId;
        this.gameSecret = gameSecret;

        this.callback = callback;

        requestAuthCode();
    }

    private void requestAuthCode() {
        String auth   = "gameUniv://gameLogin";
        String query  = "gameId=" + gameId;
        Uri uri       = Uri.parse(auth + "?" + query);

        Intent intent = new Intent(Intent.ACTION_VIEW, uri);
        startActivityForResult(intent, AUTH_CODE_REQUEST);
    }

    private void requestAccessToken() {
        AccessTokenRequest request = new AccessTokenRequest(authCode, gameId);
        RESTAPI.Tokens.getAccessToken(gameSecret, request).enqueue(new Callback<AccessToken>() {
            @Override
            public void onResponse(Response<AccessToken> response, Retrofit retrofit) {
                // TODO: Make use of expires_in
                AccessToken accessToken = response.body();
                callback.onGettingAccessToken(accessToken.getAccessToken());
            }

            @Override
            public void onFailure(Throwable t) {

            }
        });
    }
}
