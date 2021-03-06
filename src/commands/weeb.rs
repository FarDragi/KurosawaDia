use rand::{thread_rng, Rng};
use serenity::{
    builder::CreateEmbed,
    client::Context,
    framework::standard::{
        macros::{command, group},
        Args, CommandResult,
    },
    model::channel::Message,
};
use unidecode::unidecode_char;

use crate::{
    apis::get_weeb_api,
    utils::{constants::colors, user::get_user_from_args},
};

#[group]
#[commands(owoify, hug, kiss, slap, punch, lick, cry, pat, dance, megumin, rem)]
#[description("Weeb ❤️- Esse módulo é o mais amoroso de todos")]
pub struct Weeb;

#[command("hug")]
#[aliases("abraço", "abraco", "abrasar")]
#[only_in("guilds")]
#[max_args(1)]
#[description("Dê um abraço em si mesmo(a) ou em seu amiguinho")]
#[usage("hug [usuario]")]
#[example("hug @Vulcan")]
#[example("hug 203713369927057408")]
async fn hug(ctx: &Context, msg: &Message, mut args: Args) -> CommandResult {
    let api = get_weeb_api();
    let image = api.get_random("hug").await?;

    let mut embed = CreateEmbed::default();
    embed.image(image.url);
    embed.color(colors::PINK);

    let user = get_user_from_args(ctx, &mut args).await.ok();
    let title = match user {
        Some(user) => format!("{} está abraçando {}", msg.author.name, user.name),
        None => format!("{} está se abraçando", msg.author.name),
    };

    embed.title(title);

    msg.channel_id
        .send_message(ctx, |x| x.set_embed(embed).reference_message(msg))
        .await?;

    Ok(())
}

#[command("kiss")]
#[aliases("beijar", "beijo")]
#[only_in("guilds")]
#[max_args(1)]
#[description("Dê um beijo em si mesmo(a) ou em seu amiguinho")]
#[usage("kiss [usuario]")]
#[example("kiss @Vulcan")]
#[example("kiss 203713369927057408")]
async fn kiss(ctx: &Context, msg: &Message, mut args: Args) -> CommandResult {
    let api = get_weeb_api();
    let image = api.get_random("kiss").await?;

    let mut embed = CreateEmbed::default();
    embed.image(image.url);
    embed.color(colors::PINK);

    let user = get_user_from_args(ctx, &mut args).await.ok();
    let title = match user {
        Some(user) => format!("{} está beijando {}", msg.author.name, user.name),
        None => format!("{} está se beijando", msg.author.name),
    };

    embed.title(title);

    msg.channel_id
        .send_message(ctx, |x| x.set_embed(embed).reference_message(msg))
        .await?;

    Ok(())
}

#[command("slap")]
#[aliases("bater")]
#[only_in("guilds")]
#[max_args(1)]
#[description("Dê um tapa em si mesmo(a) ou em seu amiguinho")]
#[usage("slap [usuario]")]
#[example("slap @Vulcan")]
#[example("slap 203713369927057408")]
async fn slap(ctx: &Context, msg: &Message, mut args: Args) -> CommandResult {
    let api = get_weeb_api();
    let image = api.get_random("slap").await?;

    let mut embed = CreateEmbed::default();
    embed.image(image.url);
    embed.color(colors::PINK);

    let user = get_user_from_args(ctx, &mut args).await.ok();
    let title = match user {
        Some(user) => format!("{} está dando um tapa em {}", msg.author.name, user.name),
        None => format!("{} está se batendo", msg.author.name),
    };

    embed.title(title);

    msg.channel_id
        .send_message(ctx, |x| x.set_embed(embed).reference_message(msg))
        .await?;

    Ok(())
}

#[command("punch")]
#[aliases("socar")]
#[only_in("guilds")]
#[max_args(1)]
#[description("Dê um soco em si mesmo ou em seu amiguinho")]
#[usage("punch [usuario]")]
#[example("punch @Vulcan")]
#[example("punch 203713369927057408")]
async fn punch(ctx: &Context, msg: &Message, mut args: Args) -> CommandResult {
    let api = get_weeb_api();
    let image = api.get_random("punch").await?;

    let mut embed = CreateEmbed::default();
    embed.image(image.url);
    embed.color(colors::PINK);

    let user = get_user_from_args(ctx, &mut args).await.ok();
    let title = match user {
        Some(user) => format!("{} está socando {}", msg.author.name, user.name),
        None => format!("{} está se socando", msg.author.name),
    };

    embed.title(title);

    msg.channel_id
        .send_message(ctx, |x| x.set_embed(embed).reference_message(msg))
        .await?;

    Ok(())
}

#[command("lick")]
#[aliases("lamber")]
#[only_in("guilds")]
#[max_args(1)]
#[description("Dê uma lambida em si mesmo ou em seu amiguinho")]
#[usage("kick [usuario]")]
#[example("kick @Vulcan")]
#[example("kick 203713369927057408")]
async fn lick(ctx: &Context, msg: &Message, mut args: Args) -> CommandResult {
    let api = get_weeb_api();
    let image = api.get_random("lick").await?;

    let mut embed = CreateEmbed::default();
    embed.image(image.url);
    embed.color(colors::PINK);

    let user = get_user_from_args(ctx, &mut args).await.ok();
    let title = match user {
        Some(user) => format!("{} está lambendo {}", msg.author.name, user.name),
        None => format!("{} está se lambendo", msg.author.name),
    };

    embed.title(title);

    msg.channel_id
        .send_message(ctx, |x| x.set_embed(embed).reference_message(msg))
        .await?;

    Ok(())
}

#[command("cry")]
#[aliases("chorar")]
#[only_in("guilds")]
#[max_args(1)]
#[description("Chore sozinho(a) ou junto com alguém")]
#[usage("cry [usuario]")]
#[example("cry @Vulcan")]
#[example("cry 203713369927057408")]
async fn cry(ctx: &Context, msg: &Message, mut args: Args) -> CommandResult {
    let api = get_weeb_api();
    let image = api.get_random("cry").await?;

    let mut embed = CreateEmbed::default();
    embed.image(image.url);
    embed.color(colors::PINK);

    let user = get_user_from_args(ctx, &mut args).await.ok();
    let title = match user {
        Some(user) => format!("{} está chorando com {}", msg.author.name, user.name),
        None => format!("{} está chorando", msg.author.name),
    };

    embed.title(title);

    msg.channel_id
        .send_message(ctx, |x| x.set_embed(embed).reference_message(msg))
        .await?;

    Ok(())
}

#[command("pat")]
#[aliases("acariciar")]
#[only_in("guilds")]
#[max_args(1)]
#[description("Faça carinho em seu amiguinho (a não ser que você esteja carente)")]
#[usage("pat [usuario]")]
#[example("pat @Vulcan")]
#[example("pat 203713369927057408")]
async fn pat(ctx: &Context, msg: &Message, mut args: Args) -> CommandResult {
    let api = get_weeb_api();
    let image = api.get_random("pat").await?;

    let mut embed = CreateEmbed::default();
    embed.image(image.url);
    embed.color(colors::PINK);

    let user = get_user_from_args(ctx, &mut args).await.ok();
    let title = match user {
        Some(user) => format!("{} está fazendo carinho em {}", msg.author.name, user.name),
        None => format!("{} está carente", msg.author.name),
    };

    embed.title(title);

    msg.channel_id
        .send_message(ctx, |x| x.set_embed(embed).reference_message(msg))
        .await?;

    Ok(())
}

#[command("dance")]
#[aliases("dancar")]
#[only_in("guilds")]
#[max_args(1)]
#[description("Dance sozinho(a) ou com o seu amiguinho")]
#[usage("dance [usuario]")]
#[example("dance @Vulcan")]
#[example("dance 203713369927057408")]
async fn dance(ctx: &Context, msg: &Message, mut args: Args) -> CommandResult {
    let api = get_weeb_api();
    let image = api.get_random("dance").await?;

    let mut embed = CreateEmbed::default();
    embed.image(image.url);
    embed.color(colors::PINK);

    let user = get_user_from_args(ctx, &mut args).await.ok();
    let title = match user {
        Some(user) => format!("{} começou a dançar com {}", msg.author.name, user.name),
        None => format!("{} começou a dançar com a vassoura", msg.author.name),
    };

    embed.title(title);

    msg.channel_id
        .send_message(ctx, |x| x.set_embed(embed).reference_message(msg))
        .await?;

    Ok(())
}

#[command("megumin")]
#[only_in("guilds")]
#[max_args(0)]
#[description("Mostra uma imagem da Megumin")]
async fn megumin(ctx: &Context, msg: &Message) -> CommandResult {
    let api = get_weeb_api();
    let image = api.get_random("megumin").await?;

    let mut embed = CreateEmbed::default();
    embed.image(image.url);
    embed.color(colors::PINK);
    embed.title("Megumin ❤");

    msg.channel_id
        .send_message(ctx, |x| x.set_embed(embed).reference_message(msg))
        .await?;

    Ok(())
}

#[command("rem")]
#[only_in("guilds")]
#[max_args(0)]
#[description("Mostra uma imagem da Rem")]
async fn rem(ctx: &Context, msg: &Message) -> CommandResult {
    let api = get_weeb_api();
    let image = api.get_random("rem").await?;

    let mut embed = CreateEmbed::default();
    embed.image(image.url);
    embed.color(colors::PINK);
    embed.title("Rem ❤");

    msg.channel_id
        .send_message(ctx, |x| x.set_embed(embed).reference_message(msg))
        .await?;

    Ok(())
}

#[command("owoify")]
#[aliases("furroify", "furrofy", "furrar")]
#[min_args(1)]
#[description("Transforma uma frase em câncer")]
#[usage("owoify <texto>")]
#[example("owoify Olá, meu nome é Kurosawa Dia!")]
async fn owoify(ctx: &Context, msg: &Message, args: Args) -> CommandResult {
    let text = args.remains().unwrap();
    let chars = text.chars().collect::<Vec<char>>();

    if text.len() > 800 {
        return Err("Texto maior que 800".into());
    }

    let mut result = "".to_string();

    let faces = [
        " OwO ", " owo ", " oωo ", " òωó ", " °ω° ", " UwU ", " >w< ", " ^w^ ",
    ];

    let mut indexer = 0;

    loop {
        if chars.len() <= indexer {
            break;
        }

        let ch = chars[indexer];

        if ch == 'r' || ch == 'l' {
            result.push('w');
        } else if text.len() - indexer != 1 && (ch == 'n' || ch == 'N') {
            let next = chars[indexer + 1];
            let next_norm = unidecode_char(next).chars().next().unwrap();
            let next_lower = next_norm.to_lowercase().next().unwrap();

            if next_lower == 'a'
                || next_lower == 'e'
                || next_lower == 'i'
                || next_lower == 'o'
                || next_lower == 'u'
            {
                if next_norm == next_lower {
                    result.push_str(format!("{}y", ch).as_str());
                } else {
                    result.push_str(format!("{}Y", ch).as_str());
                }
            } else {
                result.push(ch);
            }
        } else if ch == 'R' || ch == 'L' {
            result.push('W');
        } else if ch == '!' {
            if indexer != 0 && chars[indexer - 1] == '@' {
                result.push(ch);
            } else if !(text.len() - indexer != 1 && chars[indexer + 1] == '!') {
                let mut rng = thread_rng();
                result.push_str(faces[rng.gen_range(0..faces.len())]);
            }
        } else if text.len() - indexer > 2 {
            if ch == 'o' && chars[indexer + 1] == 'v' && chars[indexer + 2] == 'e' {
                result.push_str("uv");
                indexer += 2;
            } else if ch == 'O' && chars[indexer + 1] == 'V' && chars[indexer + 2] == 'E' {
                result.push_str("UV");
                indexer += 2;
            } else {
                result.push(ch);
            }
        } else {
            result.push(ch);
        }

        indexer += 1;
    }

    let mut embed = CreateEmbed::default();
    embed.description(result);
    embed.color(colors::PINK);

    msg.channel_id
        .send_message(ctx, |x| x.set_embed(embed).reference_message(msg))
        .await?;

    Ok(())
}
