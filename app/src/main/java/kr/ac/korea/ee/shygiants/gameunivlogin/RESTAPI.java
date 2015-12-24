package kr.ac.korea.ee.shygiants.gameunivlogin;

import retrofit.GsonConverterFactory;
import retrofit.Retrofit;

/**
 * Created by SHYBook_Air on 2015. 12. 25..
 */
public class RESTAPI {

    private static RESTAPI ourInstance;

    public static Tokens Tokens;

    public static void init(String url) {
        if (ourInstance == null) {
            ourInstance = new RESTAPI(url);
            Tokens = create(Tokens.class);
        }
    }

    private static <T> T create(final Class<T> service) {
        return ourInstance.retrofit.create(service);
    }

    private Retrofit retrofit;

    private RESTAPI(String url) {
        retrofit = new Retrofit.Builder()
                .baseUrl(url)
                .addConverterFactory(GsonConverterFactory.create())
                .build();
        retrofit.client().setFollowRedirects(false);
    }
}
