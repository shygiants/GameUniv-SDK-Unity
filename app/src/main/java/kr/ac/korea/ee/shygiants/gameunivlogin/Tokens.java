package kr.ac.korea.ee.shygiants.gameunivlogin;

import retrofit.Call;
import retrofit.http.Body;
import retrofit.http.Header;
import retrofit.http.POST;
import retrofit.http.Path;

/**
 * Created by SHYBook_Air on 2015. 12. 25..
 */
public interface Tokens {

    @POST("/tokens/accessTokens/")
    Call<AccessToken> getAccessToken(@Header("Authorization") String gameSecret, @Body AccessTokenRequest body);
}
